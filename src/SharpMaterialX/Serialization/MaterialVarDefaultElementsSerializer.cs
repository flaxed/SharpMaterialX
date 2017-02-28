using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.Materials;
using SharpMaterialX.Serialization.Utils;

namespace SharpMaterialX.Serialization
{
    public static class MaterialVarDefaultElementsSerializer
    {
        public static bool ReadElements(DocumentDeserializationContext context, XElement root)
        {
            foreach (var materialVarDefaultElement in root.Elements("materialvardefault"))
            {
                if (ReadMaterialVarDefaultElement(materialVarDefaultElement, out var materialVarDefault) == false)
                {
                    return false;
                }

                context.MaterialVarDefaults.Add(materialVarDefault);
            }

            return true;
        }
        private static bool ReadMaterialVarDefaultElement(XElement element, out MaterialVarDefault materialVarDefault)
        {
            materialVarDefault = new MaterialVarDefault();

            if (AttributeUtils.TryReadRequired(element, "name", out string name) == false)
            {
                return false;
            }

            materialVarDefault.Name = name;

            if (AttributeUtils.TryReadRequired(element, "type", out string type) == false)
            {
                return false;
            }

            materialVarDefault.Type = type;

            if (AttributeUtils.TryReadRequiredValue(element, type, out var value) == false)
            {
                return false;
            }

            materialVarDefault.Value = value;

            return true;
        }
    }
}