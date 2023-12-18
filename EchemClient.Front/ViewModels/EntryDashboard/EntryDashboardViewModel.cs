using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.ElementService;
using EchemClient.Front.Services.EntryService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace EchemClient.Front.ViewModels.EntryDashboard
{
    public partial class EntryDashboardViewModel : ObservableObject, IEntryDashboardViewModel
    {
        [ObservableProperty]
        public CVEntry _entry = new();

        [ObservableProperty]
        public string _entryName = string.Empty;

        [ObservableProperty]
        public Element _element = new();

        private readonly IEntryService _entryService;
        private readonly IJSRuntime _jsRuntime;
        private readonly IElementService _elementService;
        private readonly NavigationManager _navigationManager;

        public EntryDashboardViewModel(IEntryService entryService, IJSRuntime jsRuntime, IElementService elementService, NavigationManager navigationManager)
        {
            _entryService = entryService;
            _jsRuntime = jsRuntime;
            _elementService = elementService;
            _navigationManager = navigationManager;
        }

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EntryDashboardViewModel() { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public async Task OnInitializedAsync() 
        {
            Entry = await _entryService.GetCVEntryByNameAsync(EntryName);
            Element = _elementService.GetElementBySymbol(Entry.We_Electrode.Material);
        }

        public void Deserialize()
        {
            var urlParameter = _navigationManager.Uri;
            var queryString = Uri.UnescapeDataString(new Uri(urlParameter).Query.TrimStart('?'));

            if (!string.IsNullOrEmpty(queryString))
            {
                var serializedName = Uri.UnescapeDataString(queryString.Split('=')[1]);
                try
                {
                    EntryName = JsonSerializer.Deserialize<string>(serializedName) ?? "";
                }
                catch (JsonException ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            }
        }

        public async Task DrawCVChart()
        {
            await _jsRuntime.InvokeVoidAsync("drawCyclicVoltammogram", "mainChart", "Cyclic Voltammogram", Entry.Name, Entry.J, Entry.E);
        }

        public async Task UpdateCVChart()
        {
            await _jsRuntime.InvokeVoidAsync("updateCyclicVoltammogram", "mainChart", "Cyclic Voltammogram", Entry.Name, Entry.J, Entry.E);
        }
    }
}
