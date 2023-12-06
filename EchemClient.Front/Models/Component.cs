namespace EchemClient.Front.Models
{
    public class Component
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Measurement? Concentration { get; set; } = new();
        public Measurement? Proportion { get; set; } = new();
        public Source? Source { get; set; } = new();
        public Purity? Purity { get; set; } = new();
    }

    public class Purity
    {
        public string? Refinement { get; set; }
        public string? Grade { get; set; }
    }

    public class Source
    {
        public string? Supplier { get; set; } = string.Empty;
        public string? Quality { get; set; }
        public SuppliedPurity? SuppliedPurity { get; set;}
    }

    public class SuppliedPurity
    {
        public Measurement? Grade { get; set; }
    }
}
