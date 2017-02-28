using System;
using System.IO;

namespace SharpMaterialX.Serialization
{
    public static class FileSerializer
    {
        public static DeserializationResult Deserialize(string path)
        {
            try
            {
                using (var stream = File.OpenRead(path))
                {
                    return StreamSerializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                return DeserializationResult.FromException(e);
            }
        }
    }
}