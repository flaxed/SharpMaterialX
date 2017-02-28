using System.Collections.Generic;

using SharpMaterialX.Serialization.Models.Headers;
using SharpMaterialX.Serialization.Models.Materials;
using SharpMaterialX.Serialization.Models.Shaders;

namespace SharpMaterialX.Serialization
{
    public class DocumentDeserializationContext
    {
        public DocumentDeserializationContext()
        {
            this.Shaders = new List<Shader>();
            this.Materials = new List<Material>();
            this.Implementations = new List<Implementation>();
            this.MaterialVarDefaults = new List<MaterialVarDefault>();
        }

        public Header Header { get; set; }

        public List<Shader> Shaders { get; }

        public List<Material> Materials { get; }

        public List<Implementation> Implementations { get; }

        public List<MaterialVarDefault> MaterialVarDefaults { get; }
    }
}