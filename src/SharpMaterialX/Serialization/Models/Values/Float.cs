namespace SharpMaterialX.Serialization.Models.Values
{
    public class Float : Value
    {
        public Float()
            : base(Types.Float)
        {
        }

        public float Value { get; set; }
    }
}