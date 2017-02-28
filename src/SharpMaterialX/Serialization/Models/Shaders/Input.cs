using SharpMaterialX.Serialization.Models.Values;

namespace SharpMaterialX.Serialization.Models.Shaders
{
    public class Input
    {
        public string Name { get; set; }

        public string PublicName { get; set; }

        public string Type { get; set; }

        public Value Value { get; set; }

        public Value DefaultValue { get; set; }

        public string OpGraph { get; set; }

        public string GraphOutput { get; set; }
    }
}