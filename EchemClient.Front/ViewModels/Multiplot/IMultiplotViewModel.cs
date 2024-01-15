using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.Multiplot
{
    public interface IMultiplotViewModel
    {
        List<CVEntry> Entries { get; set; }
        string EntryNames { get; set; }
        string ChartId { get; set; }
        bool ReferenceNormalization { get; set; }
        bool ScanRateNormalization { get; set; }
        bool ElectrolyteConcentrationNormalization { get; set; }
        string SelectedReference { get; set; }
        string LegendReference { get; set; }
        string SelectedScanRate { get; set; }
        string JUnits { get; set; }
        Dictionary<string, double> Refs { get; set; }

        Task OnInitializedAsync();
        void Deserialize();
        void NormalizeData();
        Task DrawMultipleCVCharts();
        Task UpdateMultipleCVCharts();
        Task DeleteMultipleCVCharts();
        string GenerateRandomId();
    }
}
