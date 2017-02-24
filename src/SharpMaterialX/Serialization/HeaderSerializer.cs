using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SharpMaterialX.Serialization
{
    internal class HeaderSerializer
    {
        public static bool ReadHeader(XElement root, out Header header)
        {
            header = new Header();

            if (TryReadVersion(root, header) == false)
            {
                header = null;
                return false;
            }

            if (TryReadRequireList(root, header) == false)
            {
                header = null;
                return false;
            }

            if (ColorManagementSerializer.TryReadColorConfiguration(root, header) == false)
            {
                header = null;
                return false;
            }

            if (ColorSpaceSerializer.TryReadColorSpace(root, out var colorSpace))
            {
                header.ColorSpace = colorSpace;
            }

            if (TryReadVDirection(root, header) == false)
            {
                header = null;
                return false;
            }

            return true;
        }

        private static bool TryReadVersion(XElement root, Header header)
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

            if (int.TryParse(majorToken, out int major) == false)
            {
                return false;
            }

            if (int.TryParse(minorToken, out int minor) == false)
            {
                return false;
            }

            header.Version = new Version(major, minor);

            return true;
        }

        private static bool TryReadRequireList(XElement root, Header header)
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

            header.Require = new RequireCollection(requireList);

            return true;
        }

        private static bool TryReadVDirection(XElement root, Header header)
        {
            header.VDirection = VDirection.Up;

            var directionString = root.Attribute("vdirection")?.Value;

            if (string.IsNullOrWhiteSpace(directionString))
            {
                return true;
            }

            directionString = directionString.ToLowerInvariant();

            switch (directionString)
            {
                case "up":
                    header.VDirection = VDirection.Up;
                    break;
                case "down":
                    header.VDirection = VDirection.Down;
                    break;
                default:
                    return false;
            }

            return true;
        }
    }
}