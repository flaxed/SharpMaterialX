using SharpMaterialX.Serialization.Models.Values;

namespace SharpMaterialX.Serialization.Models.Materials
{
    public class ParameterOverride
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Value Value { get; set; }
    }
}