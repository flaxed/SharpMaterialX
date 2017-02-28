using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.Shaders;
using SharpMaterialX.Serialization.Utils;

namespace SharpMaterialX.Serialization.Shaders
{
    public static class ShaderImplementationElementsSerializer
    {
        public static bool ReadElements(DocumentDeserializationContext context, XElement root)
        {
            foreach (var coshaderElement in root.Elements("implementation"))
            {
                if (ReadImplementationElement(context, coshaderElement) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ReadImplementationElement(DocumentDeserializationContext context, XElement element)
        {
            var implementation = new Implementation();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            implementation.Name = name;

            if (AttributeUtils.TryReadRequired(element, "shader", out string shader) == false)
            {
                return false;
            }

            implementation.Shader = shader;

            if (AttributeUtils.TryReadRequired(element, "shader", out string[] applications) == false)
            {
                return false;
            }

            implementation.Applications.AddRange(applications);

            if (AttributeUtils.TryReadRequired(element, "file", out string file) == false)
            {
                implementation.File = file;
            }

            if (AttributeUtils.TryReadRequired(element, "function", out string function) == false)
            {
                implementation.Function = function;
            }

            if (AttributeUtils.TryReadRequired(element, "opgraph", out string opgraph) == false)
            {
                implementation.OpGraph = opgraph;
            }

            if (AttributeUtils.TryReadRequired(element, "language", out string language) == false)
            {
                implementation.Language = language;
            }

            context.Implementations.Add(implementation);

            return true;
        }
    }
}