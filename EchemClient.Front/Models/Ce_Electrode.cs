namespace EchemClient.Front.Models
{
    public class Ce_Electrode
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string? CrystallographicOrientation { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string? Supplier { get; set; } = string.Empty;
        public string Shape { get; set; } = string.Empty;

        public Ce_Electrode() { }
    }
}
