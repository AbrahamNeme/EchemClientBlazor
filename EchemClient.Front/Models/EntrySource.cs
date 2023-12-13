﻿using System.Text;

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

        public string GetTechniques()
        {
            if (Techniques == null) { return string.Empty; }
            else
            {
                StringBuilder techniquesBuilder = new();
                foreach (var technique in Techniques)
                {
                    techniquesBuilder.Append($"{technique}, ");
                }
                if (techniquesBuilder.Length >= 2) // Check if there are at least 2 characters (length of ", ") in the string
                {
                    techniquesBuilder.Length -= 2; // Remove the last 2 characters (length of ", ")
                }
                return techniquesBuilder.ToString();
            }
        }
    }
}
