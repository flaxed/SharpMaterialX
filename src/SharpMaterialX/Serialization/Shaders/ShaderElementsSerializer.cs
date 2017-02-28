using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.Shaders;
using SharpMaterialX.Serialization.Utils;

namespace SharpMaterialX.Serialization.Shaders
{
    public class ShaderElementsSerializer
    {
        public static bool ReadElements(DocumentDeserializationContext context, XElement root)
        {
            foreach (var shaderElement in root.Elements("shader"))
            {
                if (ReadShaderElement(context, shaderElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ReadShaderElement(DocumentDeserializationContext context, XElement element)
        {
            var shader = new Shader();

            if (TryReadAttributes(shader, element) == false)
            {
                return false;
            }

            if (TryReadParameters(shader, element) == false)
            {
                return false;
            }

            if (TryReadInputs(shader, element) == false)
            {
                return false;
            }

            if (TryReadCoshaders(shader, element) == false)
            {
                return false;
            }

            if (TryReadAovs(shader, element) == false)
            {
                return false;
            }

            context.Shaders.Add(shader);

            return true;
        }

        private static bool TryReadAttributes(Shader shader, XElement element)
        {
            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            shader.Name = name;

            if (AttributeUtils.TryReadRequired(element, "shadertype", out string shaderType) == false)
            {
                return false;
            }

            shader.Type = shaderType;

            if (AttributeUtils.TryReadRequired(element, "shaderprogram", out string shaderProgram) == false)
            {
                return false;
            }

            shader.Program = shaderProgram;

            return true;
        }

        private static bool TryReadParameters(Shader shader, XElement element)
        {
            foreach (var parameterElement in element.Elements("parameter"))
            {
                if (ReadParameterElement(shader, parameterElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadInputs(Shader shader, XElement element)
        {
            foreach (var inputElement in element.Elements("input"))
            {
                if (ReadInputElement(shader, inputElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadCoshaders(Shader shader, XElement element)
        {
            foreach (var coshaderElement in element.Elements("coshader"))
            {
                if (ReadCoshaderElement(shader, coshaderElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadAovs(Shader shader, XElement element)
        {
            foreach (var coshaderElement in element.Elements("aov"))
            {
                if (ReadAovElement(shader, coshaderElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ReadParameterElement(Shader shader, XElement element)
        {
            var parameter = new Parameter();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            parameter.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            parameter.Type = type;

            if (AttributeUtils.TryReadValue(element, type, out var value) == false)
            {
                parameter.Value = value;
            }

            if (AttributeUtils.TryReadValue(element, type, "default", out var defaultValue))
            {
                parameter.DefaultValue = defaultValue;
            }

            if (AttributeUtils.TryRead(element, "publicname", out string publicName))
            {
                parameter.PublicName = publicName;
            }

            shader.Parameters.Add(parameter);

            return true;
        }

        private static bool ReadInputElement(Shader shader, XElement element)
        {
            var input = new Input();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            input.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            input.Type = type;

            if (AttributeUtils.TryReadValue(element, type, out var value) == false)
            {
                input.Value = value;
            }

            if (AttributeUtils.TryReadValue(element, type, "default", out var defaultValue))
            {
                input.DefaultValue = defaultValue;
            }

            if (AttributeUtils.TryRead(element, "opgraph", out string opGraph))
            {
                input.OpGraph = opGraph;
            }

            if (AttributeUtils.TryRead(element, "graphoutput", out string graphOutput))
            {
                input.GraphOutput = graphOutput;
            }

            if (AttributeUtils.TryRead(element, "publicname", out string publicName))
            {
                input.PublicName = publicName;
            }

            shader.Inputs.Add(input);

            return true;
        }

        private static bool ReadCoshaderElement(Shader shader, XElement element)
        {
            var coshader = new Coshader();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            coshader.Name = name;

            if (AttributeUtils.TryReadRequired(element, "shader", out string type) == false)
            {
                return false;
            }

            coshader.Shader = type;

            if (AttributeUtils.TryRead(element, "aovset", out string aovSet))
            {
                coshader.AovSet = aovSet;
            }

            if (AttributeUtils.TryRead(element, "aovs", out string aovsString))
            {
                if (TokenUtils.TryTokenize(aovsString, out var aovs))
                {
                    coshader.Aovs = aovs;
                }
            }

            shader.Coshaders.Add(coshader);

            return true;
        }

        private static bool ReadAovElement(Shader shader, XElement element)
        {
            var aov = new Aov();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            aov.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            aov.Type = type;

            shader.Aovs.Add(aov);

            return true;
        }
    }
}