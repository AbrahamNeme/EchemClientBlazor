using System.Text;

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

        public string GetAuthors()
        {
            if (Authors == null) { return string.Empty; }
            else
            {
                StringBuilder authorsBuilder = new();
                foreach (var author in Authors)
                {
                    authorsBuilder.Append($"{author}, ");
                }
                if (authorsBuilder.Length >= 2) // Check if there are at least 2 characters (length of ", ") in the string
                {
                    authorsBuilder.Length -= 2; // Remove the last 2 characters (length of ", ")
                }
                return authorsBuilder.ToString();
            }
        }
    }
}
