using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.Values;

namespace SharpMaterialX.Serialization.Utils
{
    public static class AttributeUtils
    {
        /// <summary>
        /// Tries to read the value of an attribute as a string
        /// </summary>
        /// <param name="element">The element with the attribute to be read</param>
        /// <param name="name">The name of the attribute</param>
        /// <param name="value">The value of the attribute if found. Null string otherwise.</param>
        /// <returns>True if the attribute was found. False otherwise.</returns>
        public static bool TryRead(XElement element, string name, out string value)
        {
            var attribute = element.Attribute(name);

            value = attribute?.Value;

            return attribute != null;
        }

        /// <summary>
        /// Tries to read the value of an attribute as a string. Checks if the string isn't empty or whitespace.
        /// </summary>
        /// <param name="element">The element with the attribute to be read</param>
        /// <param name="name">The name of the attribute</param>
        /// <param name="value">The value of the attribute if found. Null string otherwise.</param>
        /// <returns>True if the attribute was found and has content. False otherwise.</returns>
        public static bool TryReadRequired(XElement element, string name, out string value)
        {
            var attribute = element.Attribute(name);

            value = attribute?.Value;

            return attribute != null && string.IsNullOrWhiteSpace(value) == false;
        }

        public static bool TryReadRequired(XElement element, string name, out string[] values)
        {
            var attribute = element.Attribute(name);

            var value = attribute?.Value;

            if (TokenUtils.TryTokenize(value, out values) == false)
            {
                return false;
            }

            return values.Length > 0;
        }

        public static bool TryReadRequiredValue(XElement element, string type, out Value value)
        {
            return TryReadRequiredValue(element, type, "value", out value);
        }

        public static bool TryReadRequiredValue(XElement element, string type, string name, out Value value)
        {
            var attribute = element.Attribute(name);

            if (attribute == null)
            {
                value = null;
                return false;
            }

            return ValueParser.TryParse(type, attribute.Value, out value);
        }

        public static bool TryReadValue(XElement element, string type, out Value value)
        {
            return TryReadValue(element, type, "value", out value);
        }

        public static bool TryReadValue(XElement element, string type, string name, out Value value)
        {
            var attribute = element.Attribute(name);

            if (attribute == null)
            {
                value = null;
                return true;
            }

            return ValueParser.TryParse(type, attribute.Value, out value);
        }
    }
}
