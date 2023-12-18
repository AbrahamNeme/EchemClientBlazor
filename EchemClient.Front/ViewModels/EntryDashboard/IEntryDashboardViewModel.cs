using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public interface IEntryDashboardViewModel
    {
        CVEntry Entry { get; set; }
        string EntryName { get; set; }
        Element Element { get; set; }

        Task OnInitializedAsync();
        void Deserialize();
        Task DrawCVChart();
        Task UpdateCVChart();
    }
}
