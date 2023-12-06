namespace EchemClient.Front.Models
{
    public class EntrySource
    {
        public EntrySourceDescriptor Descriptor { get; set; } = new();

        public EntrySource() { }
    }

    public class EntrySourceDescriptor
    {
        public string CitationKey { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string[]? Techniques { get; set; } = [];
        public string Figure { get; set; } = string.Empty;
        public string Curve { get; set; } = string.Empty;
        public string BibData { get; set; } = string.Empty;
    }
}
