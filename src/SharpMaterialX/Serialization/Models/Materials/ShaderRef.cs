using System.Collections.Generic;

namespace SharpMaterialX.Serialization.Models.Materials
{
    public class ShaderRef
    {
        public ShaderRef()
        {
            this.BindParams = new List<BindParam>();
            this.BindInputs = new List<BindInput>();
        }

        public string Name { get; set; }

        public List<BindParam> BindParams { get; }

        public List<BindInput> BindInputs { get; }
    }
}