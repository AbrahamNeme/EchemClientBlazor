namespace EchemClient.Front.Models
{
    public class Ref_Electrode
    {
        public Ref_ElectrodeDescriptor _Descriptor { get; set; } = new();

        public Ref_Electrode() { }
    }

    public class Ref_ElectrodeDescriptor
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public object? Source { get; set; }
        public string? Supplier { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
