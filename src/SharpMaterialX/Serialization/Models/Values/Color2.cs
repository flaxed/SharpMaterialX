namespace SharpMaterialX.Serialization.Models.Values
{
    public class Color2 : Value
    {
        public Color2()
            : base(Types.Color2)
        {
        }

        public float Red { get; set; }

        public float Alpha { get; set; }
    }
}