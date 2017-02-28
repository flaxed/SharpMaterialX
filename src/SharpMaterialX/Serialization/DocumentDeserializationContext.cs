using System.Collections.Generic;

using SharpMaterialX.Serialization.Models.Headers;
using SharpMaterialX.Serialization.Models.Shaders;

namespace SharpMaterialX.Serialization
{
    public class DocumentDeserializationContext
    {
        public DocumentDeserializationContext()
        {
            this.Shaders = new List<Shader>();
            this.Implementations = new List<Implementation>();
        }

        public Header Header { get; set; }

        public List<Shader> Shaders { get; }

        public List<Implementation> Implementations { get; set; }
    }
}