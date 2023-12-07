using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.EntryService;
using Microsoft.JSInterop;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public partial class EntryDashboardViewModel : ObservableObject, IEntryDashboardViewModel
    {
        [ObservableProperty]
        public CVEntry _entry = new();

        [ObservableProperty]
        public string _entryName = string.Empty;

        private readonly IEntryService _entryService;
        private readonly IJSRuntime _jsRuntime;

        public EntryDashboardViewModel(IEntryService entryService, IJSRuntime jsRuntime)
        {
            _entryService = entryService;
            _jsRuntime = jsRuntime;
        }

        public async Task OnInitializedAsync() 
        {
            Entry = await _entryService.GetCVEntryByNameAsync(EntryName);
        }

        public async Task DrawCVCharts()
        {
            await _jsRuntime.InvokeVoidAsync("drawCyclicVoltammogram", "mainChart", "Current Cyclic Voltammogram", Entry.Name, Entry.J,
                                             Entry.JUnit, Entry.E, Entry.EUnit);
            await _jsRuntime.InvokeVoidAsync("drawCyclicVoltammogram", "refChart", "Reference Cyclic Voltammogram", Entry.Name, Entry.J,
                                             Entry.JUnit, Entry.E, Entry.EUnit);
        }

        public async Task UpdateCVCharts()
        {
            await _jsRuntime.InvokeVoidAsync("updateCyclicVoltammogram", "mainChart", "Current Cyclic Voltammogram", Entry.Name, Entry.J, Entry.E);
            await _jsRuntime.InvokeVoidAsync("updateCyclicVoltammogram", "refChart", "Reference Cyclic Voltammogram", Entry.Name, Entry.J, Entry.E);
        }
    }
}
