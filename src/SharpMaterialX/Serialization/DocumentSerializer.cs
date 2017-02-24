using System.Xml.Linq;

namespace SharpMaterialX.Serialization
{
    public class DocumentSerializer
    {
        public static DeserializationResult Deserialize(XDocument document)
        {
            var root = document.Root;

            if (root == null)
            {
                return DeserializationResult.CreateFailure("File is empty");
            }

            if (HeaderSerializer.ReadHeader(root, out var header) == false)
            {
                return DeserializationResult.CreateFailure("Failed to read material header");
            }

            var materialDocument = MaterialXDocument.Create(header);

            return DeserializationResult.FromDocument(materialDocument);
        }
    }
}