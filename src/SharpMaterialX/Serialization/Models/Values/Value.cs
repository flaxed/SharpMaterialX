namespace SharpMaterialX.Serialization.Models.Values
{
    public abstract class Value
    {
        protected Value(Types type)
        {
            this.Type = type;
        }

        public Types Type { get; }
    }
}
