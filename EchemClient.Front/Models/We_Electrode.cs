namespace EchemClient.Front.Models
{
    public class We_Electrode
    {
        public We_ElectrodeDescriptor _Descriptor { get; set; } = new();
        
        public We_Electrode() { }
    }

    public class We_ElectrodeDescriptor
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string? Crystallographic_orientation { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string? PreparationProcedure { get; set; }
        public We_ElectrodeShape? Shape { get; set; }
        public We_ElectrodeGeometricElectrolyteContactArea? GeometricElectrolyteContactArea { get; set; }
        public We_ElectrodeSource? Source { get; set; }
    }

    public class We_ElectrodeShape
    {
        public Measurement? Diameter { get; set; }
        public Measurement? Height { get; set; }
        public string? Type { get; set; }
    }

    public class We_ElectrodeGeometricElectrolyteContactArea
    {
        public string? Unit { get; set; }
    }

    public class We_ElectrodeSource
    {
        public string? Supplier { get; set; }
    }
}
