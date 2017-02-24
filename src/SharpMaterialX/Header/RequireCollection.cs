using System.Collections.Generic;

namespace SharpMaterialX
{
    public class RequireCollection
    {
        public RequireCollection(List<string> requires)
        {
            this.Requires = requires;
        }

        public IReadOnlyList<string> Requires { get; }
    }
}