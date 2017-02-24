using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialXTests.Deserialization.Utils;

namespace SharpMaterialXTests.Deserialization.Header
{
    [TestClass]
    [TestCategory("Header - Require")]
    public class HeaderRequireDeserializationTests
    {
        [TestMethod]
        public void DeserializeNoRequireList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx>\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.Require);
            Assert.IsNotNull(result.Header.Require.Requires);
            Assert.AreEqual(result.Header.Require.Requires.Count, 0);
        }

        [TestMethod]
        public void DeserializeEmptyRequireList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx require=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.Require);
            Assert.IsNotNull(result.Header.Require.Requires);
            Assert.AreEqual(result.Header.Require.Requires.Count, 0);
        }

        [TestMethod]
        public void DeserializeSingleRequireList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx require=\"multilayer\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.Require);
            Assert.IsNotNull(result.Header.Require.Requires);
            Assert.AreEqual(result.Header.Require.Requires.Count, 1);
        }

        [TestMethod]
        public void DeserializeMultipleRequireList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx require=\"multilayer,matopgraph,multilayer,matopgraph\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.Require);
            Assert.IsNotNull(result.Header.Require.Requires);
            Assert.AreEqual(result.Header.Require.Requires.Count, 4);
        }

        [TestMethod]
        public void DeserializeMalformedMultipleRequireList()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx require=\",multilayer,matopgraph,multilayer,matopgraph,\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.Require);
            Assert.IsNotNull(result.Header.Require.Requires);
            Assert.AreEqual(result.Header.Require.Requires.Count, 4);

            foreach (string require in result.Header.Require.Requires)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(require));
            }
        }
    }
}