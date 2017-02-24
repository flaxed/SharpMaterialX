using System;
using System.Xml.Linq;

using SharpMaterialX.ColorManagement;

namespace SharpMaterialX.Serialization
{
    internal static class ColorManagementSerializer
    {
        public static bool TryReadColorConfiguration(XElement root, Header header)
        {
            bool hasCms = TryReadCms(root, out string cms);

            bool hasCmsConfig = TryReadCmsConfig(root, out var cmsConfig);

            ColorManagementConfiguration colorManagementConfiguration;

            if (hasCms)
            {
                if (hasCmsConfig)
                {
                    colorManagementConfiguration = new ColorManagementConfiguration(cmsConfig, cms);
                }
                else
                {
                    colorManagementConfiguration = new ColorManagementConfiguration(cms);
                }
            }
            else
            {
                if (hasCmsConfig)
                {
                    colorManagementConfiguration = new ColorManagementConfiguration(cmsConfig);
                }
                else
                {
                    colorManagementConfiguration = new ColorManagementConfiguration();
                }
            }

            header.ColorManagementConfiguration = colorManagementConfiguration;

            return true;
        }

        private static bool TryReadCms(XElement root, out string cms)
        {
            cms = root.Attribute("cms")?.Value;
            return string.IsNullOrWhiteSpace(cms) == false;
        }

        private static bool TryReadCmsConfig(XElement root, out Uri cmsConfig)
        {
            var cmsPath = root.Attribute("cmsconfig")?.Value;

            if (string.IsNullOrWhiteSpace(cmsPath))
            {
                cmsConfig = null;
                return false;
            }

            return Uri.TryCreate(cmsPath, UriKind.RelativeOrAbsolute, out cmsConfig);
        }
    }
}