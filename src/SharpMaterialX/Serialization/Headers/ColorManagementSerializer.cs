using System;
using System.Xml.Linq;

using SharpMaterialX.Serialization.Models.ColorManagement;

namespace SharpMaterialX.Serialization.Headers
{
    internal static class ColorManagementSerializer
    {
        public static bool TryReadColorConfiguration(DocumentDeserializationContext context, XElement root)
        {
            bool hasCms = TryReadCms(out string cms, root);

            bool hasCmsConfig = TryReadCmsConfig(out var cmsConfig, root);

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

            context.Header.ColorManagementConfiguration = colorManagementConfiguration;

            return true;
        }

        private static bool TryReadCms(out string cms, XElement root)
        {
            cms = root.Attribute("cms")?.Value;
            return string.IsNullOrWhiteSpace(cms) == false;
        }

        private static bool TryReadCmsConfig(out Uri cmsConfig, XElement root)
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