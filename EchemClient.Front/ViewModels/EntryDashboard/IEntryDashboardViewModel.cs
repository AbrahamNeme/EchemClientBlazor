using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public interface IEntryDashboardViewModel
    {
        CVEntry Entry { get; set; }
        string EntryName { get; set; }

        Task OnInitializedAsync();
        Task DrawCVCharts();
        Task UpdateCVCharts();
    }
}
