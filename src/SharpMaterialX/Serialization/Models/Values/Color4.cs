namespace SharpMaterialX.Serialization.Models.Values
{
    public class Color4 : Value
    {
        public Color4()
            : base(Types.Color4)
        {
        }

        public float Red { get; set; }

        public float Green { get; set; }

        public float Blue { get; set; }

        public float Alpha { get; set; }
    }
}