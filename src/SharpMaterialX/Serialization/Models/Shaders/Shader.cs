using System.Collections.Generic;

namespace SharpMaterialX.Serialization.Models.Shaders
{
    public class Shader
    {
        public Shader()
        {
            this.Parameters = new List<Parameter>();
            this.Inputs = new List<Input>();
            this.Coshaders = new List<Coshader>();
            this.Aovs = new List<Aov>();
        }

        public List<Parameter> Parameters { get; }

        public List<Input> Inputs { get; }

        public List<Coshader> Coshaders { get; }

        public List<Aov> Aovs { get; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Program { get; set; }
    }
}