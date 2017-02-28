using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpMaterialX.Serialization;
using SharpMaterialX.Serialization.Models;

namespace SharpMaterialXTests.Deserialization.Utils
{
    internal static class StringDeserializationUtils
    {
        public static Document DeserializeString(string contentString)
        {
            var result = StringSerializer.Deserialize(contentString);

            Assert.IsTrue(result.IsSuccessful, result.ErrorMessage);
            Assert.IsFalse(result.HasErrors);

            return result.Document;
        }
    }
}
