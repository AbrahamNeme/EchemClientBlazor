using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public interface IEntryDashboardViewModel
    {
        CVEntry Entry { get; set; }
        string EntryName { get; set; }
        string[] XAxis { get; set; }

        Task OnInitializedAsync();
    }
}
