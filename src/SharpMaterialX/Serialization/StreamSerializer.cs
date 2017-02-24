using System;
using System.IO;
using System.Xml.Linq;

namespace SharpMaterialX.Serialization
{
    public class StreamSerializer
    {
        public static DeserializationResult Deserialize(Stream stream)
        {
            try
            {
                var document = XDocument.Load(stream);

                return DocumentSerializer.Deserialize(document);
            }
            catch (Exception e)
            {
                return DeserializationResult.FromException(e);
            }
        }
    }
}