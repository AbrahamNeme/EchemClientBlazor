namespace EchemClient.Front.Models
{
    public class Ref_Electrode
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string? Source { get; set; } = string.Empty;
        public string? Supplier { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public Ref_Electrode() { }
    }
}
