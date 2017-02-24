using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialX;

using SharpMaterialXTests.Deserialization.Utils;

namespace SharpMaterialXTests.Deserialization.Header
{
    [TestClass]
    [TestCategory("Header - VDirection")]
    public class HeaderVDirectionDeserializationTests
    {
        [TestMethod]
        public void DeserializeNoVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx>\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Up);
        }

        [TestMethod]
        public void DeserializeEmptyVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx vdirection=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Up);
        }

        [TestMethod]
        public void DeserializeUpVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx vdirection=\"up\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Up);
        }

        [TestMethod]
        public void DeserializeCapitalizedUpVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx vdirection=\"Up\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Up);
        }

        [TestMethod]
        public void DeserializeDownVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                                  "<materialx vdirection=\"down\">\r\n" +
                                  "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Down);
        }

        [TestMethod]
        public void DeserializeCapitalizedDownVDirection()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx vdirection=\"DOwn\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.AreEqual(result.Header.VDirection, VDirection.Down);
        }
    }
}