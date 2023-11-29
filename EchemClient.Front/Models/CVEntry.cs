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

        public ElectrodeDescriptor We_Electrode { get; set; } = new();
        public ElectrodeDescriptor Ref_Electrode { get; set; } = new();
        public ElectrodeDescriptor Ce_Electrode { get; set; } = new();
        public ElectrolyteDescriptor Electrolyte { get; set; } = new();
        public SourceDescriptor Source { get; set; } = new();
        public string Citation { get; set; } = string.Empty;
        public Bibliography Bibliography { get; set; } = new();

        /*public Dictionary<string, Object> WeElectrode { get; set; } = [];
        public Dictionary<string, Object> RefElectrode { get; set; } = [];
        public Dictionary<string, Object> CeElectrode { get; set; } = [];
        public Dictionary<string, Object> Electrolyte { get; set; } = [];
        public Dictionary<string, Object> Source { get; set; } = [];
        public string Citation { get; set; } = string.Empty;
        public Dictionary<string, Object> Bibliography { get; set; } = []; */

        public CVEntry() { }

    }

    public class ElectrodeDescriptor
    {
        public Descriptor _Descriptor { get; set; } = new();
    }

    public class Descriptor
    {
        public string Name { get; set; } = string.Empty;
        public string Function { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public string Crystallographic_Orientation { get; set; } = string.Empty;
        public Purity Purity { get; set; } = new();
        public PreparationProcedure Preparation_Procedure { get; set; } = new();
    }

    public class Purity
    {
        public string Grade { get; set; } = string.Empty;
    }

    public class PreparationProcedure
    {
        public string[] Description { get; set; } = [];
    }

    public class ElectrolyteDescriptor
    {
        public string Type { get; set; } = string.Empty;
        public Component[] Components { get; set; } = [];
    }

    public class Component
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Source Source { get; set; } = new();
        public Purity Purity { get; set; } = new();
    }

    public class Source
    {
        public string Refinement { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
    }

    public class SourceDescriptor
    {
        public Descriptor _Descriptor { get; set; } = new();
    }

    public class Bibliography
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Journal { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Pages { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string[] Authors { get; set; } = [];
    }

    public class Techniques
    {
        public string[] Technique { get; set; } = [];
    }
}
