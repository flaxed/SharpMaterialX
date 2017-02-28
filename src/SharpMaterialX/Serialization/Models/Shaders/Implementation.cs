using System.Collections.Generic;

namespace SharpMaterialX.Serialization.Models.Shaders
{
    public class Implementation
    {
        public Implementation()
        {
            this.Applications = new List<string>();
        }

        public List<string> Applications { get; }

        public string Name { get; set; }

        public string Shader { get; set; }

        public string File { get; set; }

        public string Function { get; set; }

        public string OpGraph { get; set; }

        public string Language { get; set; }
    }
}