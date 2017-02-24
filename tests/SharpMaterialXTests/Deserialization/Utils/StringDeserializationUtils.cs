using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialX;
using SharpMaterialX.Serialization;

namespace SharpMaterialXTests.Deserialization.Utils
{
    internal static class StringDeserializationUtils
    {
        public static MaterialXDocument DeserializeString(string contentString)
        {
            var result = StringSerializer.Deserialize(contentString);

            Assert.IsTrue(result.IsSuccessful, result.ErrorMessage);
            Assert.IsFalse(result.HasErrors);

            return result.Document;
        }
    }
}
