using SharpMaterialX.Serialization.Models.Values;

namespace SharpMaterialX.Serialization.Models.Materials
{
    public class BindParam
    {
        public string Name { get; set; }

        public string Shader { get; set; }

        public string Type { get; set; }

        public Value Value { get; set; }
    }
}