using System;

namespace SharpMaterialX.ColorManagement
{
    public class ColorSpace
    {
        private ColorSpace(string colorSpace, string textureColorSpace)
        {
            this.ColorSpaceName = colorSpace;
            this.TextureColorSpaceName = textureColorSpace;

            this.HasColorSpace = string.IsNullOrWhiteSpace(colorSpace) == false;
            this.HasTextureColorSpace = string.IsNullOrWhiteSpace(textureColorSpace) == false;

            this.IsNoneColorSpace = string.Equals(colorSpace, "none", StringComparison.OrdinalIgnoreCase);
            this.IsNoneTextureColorSpace = string.Equals(textureColorSpace, "none", StringComparison.OrdinalIgnoreCase);
        }

        public string ColorSpaceName { get; }

        public string TextureColorSpaceName { get; }

        public bool HasColorSpace { get; set; }

        public bool HasTextureColorSpace { get; set; }

        public bool IsNoneColorSpace { get; }

        public bool IsNoneTextureColorSpace { get; }

        public static ColorSpace CreateWithColorAndTextureSpaces(string colorSpace, string textureColorSpace)
        {
            return new ColorSpace(colorSpace, textureColorSpace);
        }

        public static ColorSpace CreateWithColorSpace(string colorSpace)
        {
            return new ColorSpace(colorSpace, null);
        }

        public static ColorSpace CreateWithTextureColorSpace(string textureColorSpace)
        {
            return new ColorSpace(null, textureColorSpace);
        }
    }
}