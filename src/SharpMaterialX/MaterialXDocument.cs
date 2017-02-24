namespace SharpMaterialX
{
    public class MaterialXDocument
    {
        private MaterialXDocument(Header header)
        {
            this.Header = header;
        }

        public Header Header { get; }

        public static MaterialXDocument Create(Header header)
        {
            return new MaterialXDocument(header);
        }
    }
}
