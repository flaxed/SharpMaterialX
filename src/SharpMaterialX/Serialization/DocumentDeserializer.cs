using System.Xml.Linq;

using SharpMaterialX.Serialization.Headers;
using SharpMaterialX.Serialization.Models;
using SharpMaterialX.Serialization.Shaders;

namespace SharpMaterialX.Serialization
{
    public static class DocumentDeserializer
    {
        public static DeserializationResult Deserialize(XDocument document)
        {
            var root = document.Root;

            if (root == null)
            {
                return DeserializationResult.CreateFailure("File is empty");
            }

            var context = new DocumentDeserializationContext();

            if (HeaderSerializer.ReadHeader(context, root) == false)
            {
                return DeserializationResult.CreateFailure("Failed to read material header");
            }

            if (ShaderElementsSerializer.ReadElements(context, root) == false)
            {
                return DeserializationResult.CreateFailure("Failed to read material header");
            }

            if (ShaderImplementationElementsSerializer.ReadElements(context, root) == false)
            {
                return DeserializationResult.CreateFailure("Failed to read material header");
            }

            var materialDocument = MaterialXDocument.Create(context);

            return DeserializationResult.FromDocument(materialDocument);
        }
    }
}