using System;

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

        private DeserializationResult(MaterialXDocument document)
        {
            this.Document = document;
            this.IsSuccessful = true;
            this.HasErrors = false;
        }

        public MaterialXDocument Document { get; }

        public string ErrorMessage { get; }

        public bool IsSuccessful { get; }

        public bool HasErrors { get; }

        public static DeserializationResult FromDocument(MaterialXDocument document)
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