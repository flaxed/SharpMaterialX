using System;

using SharpMaterialX.Serialization.Models;

namespace SharpMaterialX.Serialization
{
    public class DeserializationResult
    {
        private DeserializationResult(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.IsSuccessful = false;
            this.HasErrors = true;
        }

        private DeserializationResult(Document document)
        {
            this.Document = document;
            this.IsSuccessful = true;
            this.HasErrors = false;
        }

        public Document Document { get; }

        public string ErrorMessage { get; }

        public bool IsSuccessful { get; }

        public bool HasErrors { get; }

        public static DeserializationResult FromDocument(Document document)
        {
            return new DeserializationResult(document);
        }

        public static DeserializationResult FromException(Exception exception)
        {
            return new DeserializationResult(exception.ToString());
        }

        public static DeserializationResult CreateFailure(string errorMessage)
        {
            return new DeserializationResult(errorMessage);
        }
    }
}