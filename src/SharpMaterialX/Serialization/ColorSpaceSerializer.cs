using System.Xml.Linq;

using SharpMaterialX.ColorManagement;

namespace SharpMaterialX.Serialization
{
    internal static class ColorSpaceSerializer
    {
        public static bool TryReadColorSpace(XElement root, out ColorSpace colorSpace)
        {
            bool hasColorSpace = TryReadColorSpace(root, out string colorString);

            bool hasTextureColorSpace = TryReadTextureColorSpace(root, out string textureString);

            if (hasColorSpace)
            {
                if (hasTextureColorSpace)
                {
                    colorSpace = ColorSpace.CreateWithColorAndTextureSpaces(colorString, textureString);
                }
                else
                {
                    colorSpace = ColorSpace.CreateWithColorSpace(colorString);

                }
            }
            else
            {
                if (hasTextureColorSpace)
                {
                    colorSpace = ColorSpace.CreateWithTextureColorSpace(textureString);

                }
                else
                {
                    colorSpace = null;
                    return false;
                }
            }

            return true;
        }

        private static bool TryReadColorSpace(XElement root, out string colorSpace)
        {
            colorSpace = root.Attribute("colorspace")?.Value;
            return string.IsNullOrWhiteSpace(colorSpace) == false;
        }

        private static bool TryReadTextureColorSpace(XElement root, out string textureColorSpace)
        {
            textureColorSpace = root.Attribute("texturecolorspace")?.Value;
            return string.IsNullOrWhiteSpace(textureColorSpace) == false;
        }

    }
}