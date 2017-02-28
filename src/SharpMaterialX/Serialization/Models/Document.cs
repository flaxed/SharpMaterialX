using SharpMaterialX.Serialization.Models.Headers;

namespace SharpMaterialX.Serialization.Models
{
    public class Document
    {
        public Header Header { get; set; }

        internal static Document Create(DocumentDeserializationContext context)
        {
            return new Document
            {
                Header = context.Header
            };
        }
    }
}
