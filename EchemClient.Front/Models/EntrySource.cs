namespace EchemClient.Front.Models
{
    public class EntrySource
    {
        public string CitationKey { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string[]? Techniques { get; set; } = [];
        public string Figure { get; set; } = string.Empty;
        public string Curve { get; set; } = string.Empty;
        public string BibData { get; set; } = string.Empty;

        public EntrySource() { }
    }
}
