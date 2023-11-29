namespace EchemClient.Front.Models
{
    public class Element
    {

        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public int AtomicNumber { get; set; }
        public double AtomicWeight { get; set; }

        public Element() { }

        public Element(string symbol, string name, string group, int atomicNumber, double atomicWeight)
        {
            Name = name;
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            AtomicWeight = atomicWeight;
            Group = group;
        }
    }
}
