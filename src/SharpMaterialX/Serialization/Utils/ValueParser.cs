using System.Globalization;

using SharpMaterialX.Serialization.Models.Values;

namespace SharpMaterialX.Serialization.Utils
{
    public static class ValueParser
    {
        public static bool TryParse(string type, string valueString, out Value value)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                value = null;
                return false;
            }

            type = type.ToLowerInvariant();

            switch (type)
            {
                case "integer": break;
                case "boolean": break;
                case "float":
                    return TryParseFloat(valueString, out value);

                case "color2":
                    return TryParseColor2(valueString, out value);
                case "color3":
                    return TryParseColor3(valueString, out value);
                case "color4":
                    return TryParseColor4(valueString, out value);

                case "vector2": break;
                case "vector3": break;
                case "vector4": break;
                case "matrix": break;
                case "string": break;
                case "filename": break;
                case "opgraphnode": break;
                case "opgraphname": break;
                case "shadernode": break;
                case "integerarray": break;
                case "floatarray": break;
                case "color2array": break;
                case "color3array": break;
                case "color4array": break;
                case "vector2array": break;
                case "vector3array": break;
                case "vector4array": break;
                case "stringarray": break;

                default:
                    value = null;
                    return false;
            }

            throw new System.NotImplementedException();
        }

        private static bool TryParseFloat(string valueString, out Value value)
        {
            var floatValue = new Float();

            if (TryParseFloats(valueString, 1, out var floats) == false)
            {
                value = null;
                return false;
            }

            floatValue.Value = floats[0];

            value = floatValue;
            return true;
        }

        public static bool TryParseColor2(string valueString, out Value value)
        {
            var color = new Color2();

            if (TryParseFloats(valueString, 2, out var floats) == false)
            {
                value = null;
                return false;
            }

            color.Red = floats[0];
            color.Alpha = floats[1];

            value = color;
            return true;
        }

        public static bool TryParseColor3(string valueString, out Value value)
        {
            var color = new Color3();

            if (TryParseFloats(valueString, 3, out var floats) == false)
            {
                value = null;
                return false;
            }

            color.Red = floats[0];
            color.Green = floats[1];
            color.Blue = floats[2];

            value = color;
            return true;
        }

        public static bool TryParseColor4(string valueString, out Value value)
        {
            var color = new Color4();

            if (TryParseFloats(valueString, 4, out var floats) == false)
            {
                value = null;
                return false;
            }

            color.Red = floats[0];
            color.Green = floats[1];
            color.Blue = floats[2];
            color.Alpha = floats[3];

            value = color;
            return true;
        }

        private static bool TryParseFloats(string input, int requiredCount, out float[] floats)
        {
            if (TokenUtils.TryTokenize(input, requiredCount, out var tokens) == false)
            {
                if (tokens == null)
                {
                    floats = null;
                    return false;
                }
            }

            floats = new float[tokens.Length];

            bool success = true;

            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];

                success = float.TryParse(token, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out float value) && success;

                floats[i] = value;
            }

            return success;
        }

        internal static bool TryParseInts(string input, int requiredCount, out int[] ints)
        {
            if (TokenUtils.TryTokenize(input, requiredCount, out var tokens) == false)
            {
                if (tokens == null)
                {
                    ints = null;
                    return false;
                }
            }

            ints = new int[tokens.Length];

            bool success = true;

            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];

                success = int.TryParse(token, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out int value) && success;

                ints[i] = value;
            }

            return success;
        }
    }
}
