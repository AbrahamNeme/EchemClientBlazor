namespace EchemClient.Front.Models
{
    public class CVEntry
    {
        public string Name { get; set; } = string.Empty;
        public List<double> T { get; set; } = [];
        public string TUnit { get; set; } = string.Empty;
        public List<double> E { get; set; } = [];
        public string EUnit { get; set; } = string.Empty;
        public List<double> J { get; set; } = [];
        public string JUnit { get; set; } = string.Empty;
        public Dictionary<string, Object> WeElectrode { get; set; } = [];
        public Dictionary<string, Object> RefElectrode { get; set; } = [];
        public Dictionary<string, Object> CeElectrode { get; set; } = [];
        public Dictionary<string, Object> Electrolyte { get; set; } = [];
        public Dictionary<string, Object> Source { get; set; } = [];
        public string Citation { get; set; } = string.Empty;
        public Dictionary<string, Object> Bibliography { get; set; } = [];

        public CVEntry() { }
    }
}
