using System.Collections.Generic;
using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.Materials;
using SharpMaterialX.Serialization.Utils;

namespace SharpMaterialX.Serialization.Materials
{
    public class MaterialElementsSerializer
    {
        public static bool ReadElements(DocumentDeserializationContext context, XElement root)
        {
            foreach (var materialElement in root.Elements("material"))
            {
                if (ReadMaterialElement(context, materialElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ReadMaterialElement(DocumentDeserializationContext context, XElement element)
        {
            var material = new Material();

            if (TryReadAttributes(material, element) == false)
            {
                return false;
            }

            if (TryReadInherits(material, element) == false)
            {
                return false;
            }

            if (TryReadVars(material, element) == false)
            {
                return false;
            }

            if (TryReadShaderRefs(material, element) == false)
            {
                return false;
            }

            if (TryReadOverrides(material, element) == false)
            {
                return false;
            }

            if (TryReadBindParams(element, out var bindParams) == false)
            {
                return false;
            }

            material.BindParams.AddRange(bindParams);

            if (TryReadBindInputs(element, out var bindInputs) == false)
            {
                return false;
            }

            material.BindInputs.AddRange(bindInputs);

            context.Materials.Add(material);

            return true;
        }

        private static bool TryReadAttributes(Material material, XElement element)
        {
            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            material.Name = name;

            return true;
        }

        private static bool TryReadInherits(Material material, XElement element)
        {
            foreach (var parameterElement in element.Elements("materialinherit"))
            {
                if (ReadInheritElement(material, parameterElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadVars(Material material, XElement element)
        {
            foreach (var parameterElement in element.Elements("materialvar"))
            {
                if (ReadMaterialVarElement(material, parameterElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadShaderRefs(Material material, XElement element)
        {
            foreach (var parameterElement in element.Elements("shaderref"))
            {
                if (ReadShaderRefElement(material, parameterElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadOverrides(Material material, XElement element)
        {
            foreach (var parameterElement in element.Elements("override"))
            {
                if (ReadShaderOverrideElement(material, parameterElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadBindParams(XElement element, out List<BindParam> bindParams)
        {
            bindParams = new List<BindParam>();

            foreach (var bindParamElement in element.Elements("bindparam"))
            {
                if (TryReadBindParam(bindParamElement, out var bindParam) == false)
                {
                    return false;
                }

                bindParams.Add(bindParam);
            }

            return true;
        }

        private static bool TryReadBindInputs(XElement element, out List<BindInput> bindInputs)
        {
            bindInputs = new List<BindInput>();

            foreach (var bindInputElement in element.Elements("bindinput"))
            {
                if (TryReadBindInput(bindInputElement, out var bindInput) == false)
                {
                    return false;
                }

                bindInputs.Add(bindInput);
            }

            return true;
        }

        private static bool ReadInheritElement(Material material, XElement element)
        {
            var inherit = new MaterialInherit();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            inherit.Name = name;

            material.Inherits.Add(inherit);

            return true;
        }

        private static bool ReadMaterialVarElement(Material material, XElement element)
        {
            var materialVar = new MaterialVar();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            materialVar.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            materialVar.Type = type;

            if (AttributeUtils.TryReadRequiredValue(element, type, out var value) == false)
            {
                return false;
            }

            materialVar.Value = value;

            material.Vars.Add(materialVar);

            return true;
        }

        private static bool ReadShaderRefElement(Material material, XElement element)
        {
            var shaderRef = new ShaderRef();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            shaderRef.Name = name;

            if (TryReadBindParams(element, out var bindParams) == false)
            {
                return false;
            }

            shaderRef.BindParams.AddRange(bindParams);

            if (TryReadBindInputs(element, out var bindInputs) == false)
            {
                return false;
            }

            shaderRef.BindInputs.AddRange(bindInputs);

            material.ShaderRefs.Add(shaderRef);

            return true;
        }

        private static bool ReadShaderOverrideElement(Material material, XElement element)
        {
            var paramOverride = new ParameterOverride();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            paramOverride.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            paramOverride.Type = type;

            // TODO: This value can have an inline value or be a reference to a materialvar
            // TODO: Add support for this case
            if (AttributeUtils.TryReadRequiredValue(element, type, out var value) == false)
            {
                return false;
            }

            paramOverride.Value = value;

            material.Overrides.Add(paramOverride);

            return true;
        }

        private static bool TryReadBindParam(XElement element, out BindParam bindParam)
        {
            bindParam = new BindParam();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            bindParam.Name = name;

            if (AttributeUtils.TryRead(element, "shader", out string shader) == false)
            {
                bindParam.Shader = shader;
            }

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            bindParam.Type = type;

            // TODO: This value can have an inline value or be a reference to a materialvar
            // TODO: Add support for this case
            if (AttributeUtils.TryReadRequiredValue(element, type, out var value) == false)
            {
                return false;
            }

            bindParam.Value = value;

            return true;
        }

        private static bool TryReadBindInput(XElement element, out BindInput bindInput)
        {
            bindInput = new BindInput();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            bindInput.Name = name;

            if (AttributeUtils.TryRead(element, "shader", out string shader) == false)
            {
                bindInput.Shader = shader;
            }

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            bindInput.Type = type;

            // TODO: This value can have an inline value or be a reference to a materialvar
            // TODO: Add support for this case
            if (AttributeUtils.TryReadValue(element, type, out var value) == false)
            {
                bindInput.Value = value;
            }

            if (AttributeUtils.TryRead(element, "opgraph", out string opGraph) == false)
            {
                bindInput.OpGraph = opGraph;
            }

            if (AttributeUtils.TryRead(element, "graphoutput", out string graphOutput) == false)
            {
                bindInput.GraphOutput = graphOutput;
            }

            return true;
        }
    }
}