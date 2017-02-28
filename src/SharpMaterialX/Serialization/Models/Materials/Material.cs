using System.Collections.Generic;

namespace SharpMaterialX.Serialization.Models.Materials
{
    public class Material
    {
        public Material()
        {
            this.Inherits = new List<MaterialInherit>();
            this.Vars = new List<MaterialVar>();
            this.ShaderRefs = new List<ShaderRef>();
            this.BindParams = new List<BindParam>();
            this.BindInputs = new List<BindInput>();
            this.Overrides = new List<ParameterOverride>();
        }

        public string Name { get; set; }

        public List<MaterialInherit> Inherits { get; }

        public List<MaterialVar> Vars { get; }

        public List<ShaderRef> ShaderRefs { get; }

        public List<BindParam> BindParams { get; }

        public List<BindInput> BindInputs { get; }

        public List<ParameterOverride> Overrides { get; }
    }
}