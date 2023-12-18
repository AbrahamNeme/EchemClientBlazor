using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.EntriesSearch
{
    public interface IEntriesSearchViewModel
    {
        List<Element> Elements { get; set; }
        List<CVEntry> Entries { get; set; }
        HashSet<CVEntry> SelectedEntries { get; set; }

        Task OnInitializedAsync();
        void Deserialize();
        void GoToEntryDashboard(string entryName);
        void GoToMultiplot();
        bool IsMultiplotDisabled();
    }
}
