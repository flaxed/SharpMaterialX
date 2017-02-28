using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

using SharpMaterialX.Serialization.Models;
using SharpMaterialX.Serialization.Models.Headers;

using Version = SharpMaterialX.Serialization.Models.Version;

namespace SharpMaterialX.Serialization.Headers
{
    internal class HeaderSerializer
    {
        public static bool ReadHeader(DocumentDeserializationContext context, XElement root)
        {
            context.Header = new Header();

            if (TryReadVersion(context, root) == false)
            {
                return false;
            }

            if (TryReadRequireList(context, root) == false)
            {
                return false;
            }

            if (ColorManagementSerializer.TryReadColorConfiguration(context, root) == false)
            {
                return false;
            }

            if (ColorSpaceSerializer.TryReadColorSpace(root, context) == false)
            {
                return false;
            }

            if (TryReadVDirection(context, root) == false)
            {
                return false;
            }

            return true;
        }

        private static bool TryReadVersion(DocumentDeserializationContext context, XElement root)
        {
            var versionString = root.Attribute("version")?.Value;

            if (string.IsNullOrWhiteSpace(versionString))
            {
                return true;
            }

            var versionTokens = versionString.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (versionTokens.Length != 2)
            {
                return false;
            }

            var majorToken = versionTokens[0];
            var minorToken = versionTokens[1];

            if (int.TryParse(majorToken, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out int major) == false)
            {
                return false;
            }

            if (int.TryParse(minorToken, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out int minor) == false)
            {
                return false;
            }

            context.Header.Version = new Version(major, minor);

            return true;
        }

        private static bool TryReadRequireList(DocumentDeserializationContext context, XElement root)
        {
            var requireString = root.Attribute("require")?.Value;

            var requireList = new List<string>();

            if (requireString != null)
            {
                foreach (string token in requireString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var requireToken = token?.Trim();

                    if (string.IsNullOrWhiteSpace(requireToken) == false)
                    {
                        requireList.Add(requireToken);
                    }
                }
            }

            context.Header.Require = new RequireCollection(requireList);

            return true;
        }

        private static bool TryReadVDirection(DocumentDeserializationContext context, XElement root)
        {
            context.Header.VDirection = VDirection.Up;

            var directionString = root.Attribute("vdirection")?.Value;

            if (string.IsNullOrWhiteSpace(directionString))
            {
                return true;
            }

            directionString = directionString.ToLowerInvariant();

            switch (directionString)
            {
                case "up":
                    context.Header.VDirection = VDirection.Up;
                    break;
                case "down":
                    context.Header.VDirection = VDirection.Down;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}