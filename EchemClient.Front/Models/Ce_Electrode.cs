namespace EchemClient.Front.Models
{
    public class Ce_Electrode
    {
        public Ce_ElectrodeDescriptor _Descriptor { get; set; } = new();

        public Ce_Electrode() { }
    }

    public class Ce_ElectrodeDescriptor
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string? Crystallographic_orientation { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string? Supplier { get; set; }
        public string Shape { get; set; } = string.Empty;
    }
}
