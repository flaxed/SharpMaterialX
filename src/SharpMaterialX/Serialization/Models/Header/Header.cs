using SharpMaterialX.Serialization.Models.ColorManagement;

namespace SharpMaterialX.Serialization.Models.Headers
{
    public class Header
    {
        public Version Version { get; set; }

        public RequireCollection Require { get; set; }

        public ColorManagementConfiguration ColorManagementConfiguration { get; set; }

        public ColorSpace ColorSpace { get; set; }

        public VDirection VDirection { get; set; }
    }
}
