using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.Multiplot
{
    public interface IMultiplotViewModel
    {
        List<CVEntry> Entries { get; set; }
        string EntryNames { get; set; }
        string ChartId { get; set; }

        Task OnInitializedAsync();
        void Deserialize();
        Task DrawMultipleCVCharts();
        Task UpdateMultipleCVCharts();
        Task DeleteMultipleCVCharts();
        string GenerateRandomId();
    }
}
