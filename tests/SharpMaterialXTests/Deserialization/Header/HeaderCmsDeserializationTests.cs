using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialXTests.Deserialization.Utils;

namespace SharpMaterialXTests.Deserialization.Header
{
    [TestClass]
    [TestCategory("Header - Color Management System")]
    public class HeaderCmsDeserializationTests
    {
        [TestMethod]
        public void DeserializeNoCmsAndNoConfig()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx>\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasConfigurationFile);
        }

        [TestMethod]
        public void DeserializeEmptyCms()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx cms=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasConfigurationFile);
        }

        [TestMethod]
        public void DeserializeEmptyConfig()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx cmsconfig=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasConfigurationFile);
        }

        [TestMethod]
        public void DeserializeEmptyCmsAndConfig()
        {
            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<materialx cms=\"\" cmsconfig=\"\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasConfigurationFile);
        }

        [TestMethod]
        public void DeserializeCms()
        {
            const string CmsName = "ocio";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
               $"<materialx cms=\"{CmsName}\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsTrue(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasConfigurationFile);

            Assert.AreEqual(result.Header.ColorManagementConfiguration.CmsName, CmsName);
        }

        [TestMethod]
        public void DeserializeConfiguration()
        {
            const string CmsConfigPath = "mx_config.ocio";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
               $"<materialx cmsconfig=\"{CmsConfigPath}\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNotNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsFalse(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsTrue(result.Header.ColorManagementConfiguration.HasConfigurationFile);
        }

        [TestMethod]
        public void DeserializeCmsAndConfiguration()
        {
            const string CmsName = "ocio";

            const string CmsConfigPath = "mx_config.ocio";

            string headerString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
               $"<materialx cms=\"{CmsName}\" cmsconfig=\"{CmsConfigPath}\">\r\n" +
                "</materialx>";

            var result = StringDeserializationUtils.DeserializeString(headerString);

            Assert.IsNotNull(result.Header);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration);

            Assert.IsNotNull(result.Header.ColorManagementConfiguration.CmsName);
            Assert.IsNotNull(result.Header.ColorManagementConfiguration.ConfigurationFile);

            Assert.IsTrue(result.Header.ColorManagementConfiguration.HasCms);
            Assert.IsTrue(result.Header.ColorManagementConfiguration.HasConfigurationFile);

            Assert.AreEqual(result.Header.ColorManagementConfiguration.CmsName, CmsName);
        }
    }
}