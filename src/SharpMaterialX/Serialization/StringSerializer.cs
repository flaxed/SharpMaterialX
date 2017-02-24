using System;
using System.Xml.Linq;

namespace SharpMaterialX.Serialization
{
    public class StringSerializer
    {
        public static DeserializationResult Deserialize(string content)
        {
            try
            {
                var document = XDocument.Parse(content);

                return DocumentSerializer.Deserialize(document);
            }
            catch (Exception e)
            {
                return DeserializationResult.FromException(e);
            }
        }
    }
}