using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.EntriesSearch
{
    public interface IEntriesSearchViewModel
    {
        List<Element> Elements { get; set; }
        List<CVEntry> Entries { get; set; }

        Task OnInitializedAsync();
    }
}
