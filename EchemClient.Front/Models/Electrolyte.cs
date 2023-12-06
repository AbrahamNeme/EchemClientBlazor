namespace EchemClient.Front.Models
{
    public class Electrolyte
    {
        public ElectrolyteDescriptor _Descriptor { get; set; } = new();

        public Electrolyte() { }
    }

    public class ElectrolyteDescriptor
    {
        public List<Component> Components { get; set; } = [];
        public Ph? Ph { get; set; }
        public Temperature? Temperature { get; set; }
        public string? Type { get; set; }
    }

    public class Ph
    {
        public decimal Value { get; set; }
    }

    public class Temperature
    {
        public string? Unit { get; set; }
        public decimal Value { get; set; }
    }
}
