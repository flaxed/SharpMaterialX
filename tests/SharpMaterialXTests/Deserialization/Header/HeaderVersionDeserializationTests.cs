using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialX.Serialization;

using SharpMaterialXTests.Deserialization.Utils;

namespace SharpMaterialXTests.Deserialization.Header
{
    [TestClass]
    [TestCategory("Header - Version")]
    public class HeaderVersionDeserializationTests
    {
        [TestMethod]
        public void DeserializeNoVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx>\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);
            Assert.IsNull(result.Header.Version);
        }

        [TestMethod]
        public void DeserializeEmptyVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);
            Assert.IsNull(result.Header.Version);
        }

        [TestMethod]
        public void DeserializeGarbageStringVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"134asdasd\">\r\n" +
                "</materialx>";

            var result = StringSerializer.Deserialize(headerString);

            Assert.IsTrue(result.HasErrors);
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void DeserializeGarbageMajorVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"asas.0\">\r\n" +
                "</materialx>";

            var result = StringSerializer.Deserialize(headerString);

            Assert.IsTrue(result.HasErrors);
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void DeserializeGarbageMinorVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"1.asasas\">\r\n" +
                "</materialx>";

            var result = StringSerializer.Deserialize(headerString);

            Assert.IsTrue(result.HasErrors);
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void DeserializeWrongVersionFormatList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"1.0.0.0\">\r\n" +
                "</materialx>";

            var result = StringSerializer.Deserialize(headerString);

            Assert.IsTrue(result.HasErrors);
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void DeserializeGarbageWrongVersionFormatList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"asas.asas.asas.asassa\">\r\n" +
                "</materialx>";

            var result = StringSerializer.Deserialize(headerString);

            Assert.IsTrue(result.HasErrors);
            Assert.IsFalse(result.IsSuccessful);
        }

        [TestMethod]
        public void DeserializeCorrectVersionList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx version=\"1.0\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);
            Assert.IsNotNull(result.Header.Version);

            Assert.AreEqual(result.Header.Version.Major, 1);
            Assert.AreEqual(result.Header.Version.Minor, 0);
        }
    }
}