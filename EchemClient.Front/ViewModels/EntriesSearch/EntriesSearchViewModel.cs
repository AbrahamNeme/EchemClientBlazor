using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.EntryService;
using Microsoft.JSInterop;

namespace EchemClient.Front.ViewModels.EntriesSearch
{
    public partial class EntriesSearchViewModel: ObservableRecipient, IEntriesSearchViewModel
    {
        [ObservableProperty]
        public List<Element> _elements = [];

        [ObservableProperty]
        public List<CVEntry> _entries = [];

        private readonly IJSRuntime _jsRuntime;
        private readonly IEntryService _entryService;

        public EntriesSearchViewModel(IJSRuntime jsRuntime, IEntryService entryService) 
        {
            _jsRuntime = jsRuntime;
            _entryService = entryService;
        }

        public async Task OnInitializedAsync()
        {
            Entries.Clear();
            foreach (var element in Elements) 
            {
                Entries.AddRange(await _entryService.GetCVEntriesByMaterialAsync(element.Symbol));
            }
            await _jsRuntime.InvokeVoidAsync("console.log", $"{Entries[0].Citation}");
        }
    }
}
