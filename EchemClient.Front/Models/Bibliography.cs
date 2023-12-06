namespace EchemClient.Front.Models
{
    public class Bibliography
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Journal { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Pages { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string? Publisher { get; set; } = string.Empty;
        public string[] Authors { get; set; } = [];

        public Bibliography() { }
    }
}
