using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialXTests.Deserialization.Utils;

namespace SharpMaterialXTests.Deserialization.Header
{
    [TestClass]
    [TestCategory("Header - Color Spaces")]
    public class HeaderColorSpaceDeserializationTests
    {
        [TestMethod]
        public void DeserializeNoColorSpaces()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx>\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            var colorSpace = result.Header.ColorSpace;

            Assert.IsNull(colorSpace);
        }

        [TestMethod]
        public void DeserializeEmptyColorSpace()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx colorspace=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNull(result.Header.ColorSpace);
        }

        [TestMethod]
        public void DeserializeEmptyTextureColorSpace()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx texturecolorspace=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNull(result.Header.ColorSpace);
        }

        [TestMethod]
        public void DeserializeEmptyColorAndTextureColorSpace()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx colorspace=\"\" texturecolorspace=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNull(result.Header.ColorSpace);
        }

        [TestMethod]
        public void DeserializeColorSpace()
        {
            const string ColorSpaceName = "scene_linear";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                                  $"<materialx colorspace=\"{ColorSpaceName}\">\r\n" +
                                  "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            var colorSpace = result.Header.ColorSpace;

            Assert.IsNotNull(colorSpace);

            Assert.IsNotNull(colorSpace.ColorSpaceName);
            Assert.IsNull(colorSpace.TextureColorSpaceName);

            Assert.IsTrue(colorSpace.HasColorSpace);
            Assert.IsFalse(colorSpace.HasTextureColorSpace);

            Assert.IsFalse(colorSpace.IsNoneColorSpace);
            Assert.IsFalse(colorSpace.IsNoneTextureColorSpace);

            Assert.AreEqual(colorSpace.ColorSpaceName, ColorSpaceName);
        }

        [TestMethod]
        public void DeserializeTextureColorSpace()
        {
            const string TextureColorSpaceName = "scene_linear";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                                  $"<materialx texturecolorspace=\"{TextureColorSpaceName}\">\r\n" +
                                  "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            var colorSpace = result.Header.ColorSpace;

            Assert.IsNotNull(colorSpace);

            Assert.IsNull(colorSpace.ColorSpaceName);
            Assert.IsNotNull(colorSpace.TextureColorSpaceName);

            Assert.IsFalse(colorSpace.HasColorSpace);
            Assert.IsTrue(colorSpace.HasTextureColorSpace);

            Assert.IsFalse(colorSpace.IsNoneColorSpace);
            Assert.IsFalse(colorSpace.IsNoneTextureColorSpace);

            Assert.AreEqual(colorSpace.TextureColorSpaceName, TextureColorSpaceName);
        }

        [TestMethod]
        public void DeserializeColorAndTextureColorSpace()
        {
            const string ColorSpaceName = "scene_linear";

            const string TextureColorSpaceName = "scene_linear";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                                  $"<materialx colorspace=\"{ColorSpaceName}\" texturecolorspace=\"{TextureColorSpaceName}\">\r\n" +
                                  "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            var colorSpace = result.Header.ColorSpace;

            Assert.IsNotNull(colorSpace);

            Assert.IsNotNull(colorSpace.ColorSpaceName);
            Assert.IsNotNull(colorSpace.TextureColorSpaceName);

            Assert.IsTrue(colorSpace.HasColorSpace);
            Assert.IsTrue(colorSpace.HasTextureColorSpace);

            Assert.IsFalse(colorSpace.IsNoneColorSpace);
            Assert.IsFalse(colorSpace.IsNoneTextureColorSpace);

            Assert.AreEqual(colorSpace.ColorSpaceName, ColorSpaceName);
            Assert.AreEqual(colorSpace.TextureColorSpaceName, TextureColorSpaceName);
        }
    }
}