namespace SharpMaterialX.Serialization.Models.Values
{
    public class Color3 : Value
    {
        public Color3()
            : base(Types.Color3)
        {
        }

        public float Red { get; set; }

        public float Green { get; set; }

        public float Blue { get; set; }
    }
}