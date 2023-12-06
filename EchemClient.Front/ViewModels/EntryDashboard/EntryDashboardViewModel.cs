using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.EntryService;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public partial class EntryDashboardViewModel : ObservableObject, IEntryDashboardViewModel
    {
        [ObservableProperty]
        public CVEntry _entry = new();

        [ObservableProperty]
        public string _entryName = string.Empty;

        [ObservableProperty]
        public string[] _xAxis = [];

        private readonly IEntryService _entryService;

        public EntryDashboardViewModel(IEntryService entryService)
        {
            _entryService = entryService;
        }

        public async Task OnInitializedAsync() 
        {
            Entry = await _entryService.GetCVEntryByNameAsync(EntryName);
            XAxis = Entry.E.Select(d => d.ToString()).ToArray();
        }
    }
}
