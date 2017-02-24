namespace SharpMaterialX
{
    public class Version
    {
        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; }

        public int Minor { get; }

        public override string ToString()
        {
            return $"{this.Major}.{this.Minor}";
        }
    }
}