using System;
using System.Xml.Linq;

namespace SharpMaterialX.Serialization
{
    public static class StringSerializer
    {
        public static DeserializationResult Deserialize(string content)
        {
            try
            {
                var document = XDocument.Parse(content);

                return DocumentDeserializer.Deserialize(document);
            }
            catch (Exception e)
            {
                return DeserializationResult.FromException(e);
            }
        }
    }
}