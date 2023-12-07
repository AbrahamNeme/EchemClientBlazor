namespace EchemClient.Front.Models
{
    public class Electrolyte
    {
        public List<Component> Components { get; set; } = [];
        public Ph? Ph { get; set; } = new();
        public Temperature? Temperature { get; set; } = new();
        public string? Type { get; set; } = string.Empty;

        public Electrolyte() { }
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
