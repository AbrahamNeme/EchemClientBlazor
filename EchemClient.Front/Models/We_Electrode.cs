namespace EchemClient.Front.Models
{
    public class We_Electrode
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string CrystallographicOrientation { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string? PreparationProcedure { get; set; } = string.Empty;
        public We_ElectrodeShape? Shape { get; set; } = new();
        public string? GeometricElectrolyteContactArea { get; set; } = string.Empty;
        public We_ElectrodeSource? Source { get; set; } = new();

        public We_Electrode() { }
    }

    public class We_ElectrodeShape
    {
        public Measurement? Diameter { get; set; } = new();
        public Measurement? Height { get; set; } = new();
        public string? Type { get; set; } = string.Empty;
    }

    public class We_ElectrodeSource
    {
        public string? Supplier { get; set; }
    }
}
