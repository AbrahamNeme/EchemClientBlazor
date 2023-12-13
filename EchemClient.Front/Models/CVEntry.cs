using System.Text;

namespace EchemClient.Front.Models
{
    public class CVEntry
    {
        public string Name { get; set; } = string.Empty;
        public double[] T { get; set; } = [];
        public string TUnit { get; set; } = string.Empty;
        public double[] E { get; set; } = [];
        public string EUnit { get; set; } = string.Empty;
        public double[] J { get; set; } = [];
        public string JUnit { get; set; } = string.Empty;

        public We_Electrode We_Electrode { get; set; } = new();
        public Ref_Electrode Ref_Electrode { get; set; } = new();
        public Ce_Electrode? Ce_Electrode { get; set; } = new();
        public Electrolyte Electrolyte { get; set; } = new();
        public EntrySource Source { get; set; } = new();
        public string Citation { get; set; } = string.Empty;
        public Bibliography Bibliography { get; set; } = new();

        public CVEntry() { }

        public string GetElectrolyteComposition()
        {
            StringBuilder compositionBuilder = new();

            foreach (var component in Electrolyte.Components)
            {
                if (component.Name == "water") { compositionBuilder.Append($"{component.Concentration?.Value} H2O + "); }
                else { compositionBuilder.Append($"{component.Concentration?.Value} {component.Name} + "); }
            }
            if (compositionBuilder.Length >= 3) // Check if there are at least 3 characters (length of " + ") in the string
            {
                compositionBuilder.Length -= 3; // Remove the last 3 characters (length of " + ")
            }
            return compositionBuilder.ToString();
        }

    }
}
