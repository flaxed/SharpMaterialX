using SharpMaterialX.Serialization.Models.Headers;

namespace SharpMaterialX.Serialization.Models
{
    public class MaterialXDocument
    {
        public Header Header { get; set; }

        internal static MaterialXDocument Create(DocumentDeserializationContext context)
        {
            return new MaterialXDocument
            {
                Header = context.Header
            };
        }
    }
}
