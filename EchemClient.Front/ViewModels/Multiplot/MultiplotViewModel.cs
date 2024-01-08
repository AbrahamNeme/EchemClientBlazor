using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.EntryService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;

namespace EchemClient.Front.ViewModels.Multiplot
{
    public partial class MultiplotViewModel : ObservableObject, IMultiplotViewModel
    {
        [ObservableProperty]
        public List<CVEntry> _entries = [];

        [ObservableProperty]
        public string _entryNames = string.Empty;

        [ObservableProperty]
        public string[] _datasetNames = [];

        [ObservableProperty]
        public double[][] _eData = [];

        [ObservableProperty]
        public double[][] _jData = [];

        [ObservableProperty]
        public bool _hasDeleted = false;

        [ObservableProperty]
        public string _chartId = string.Empty;

        private readonly IEntryService _entryService;
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;

        public MultiplotViewModel(IEntryService entryService, IJSRuntime jsRuntime, NavigationManager navigationManager)
        {
            _entryService = entryService;
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }

        public async Task OnInitializedAsync()
        {
            Entries = await _entryService.GetCVEntriesByNameAsync(EntryNames);
            PopulateChartDatasets();   
        }

        public void Deserialize()
        {
            var urlParameter = _navigationManager.Uri;
            var queryString = Uri.UnescapeDataString(new Uri(urlParameter).Query.TrimStart('?'));

            if (!string.IsNullOrEmpty(queryString))
            {
                var serializedList = Uri.UnescapeDataString(queryString.Split('=')[1]);
                try
                {
                    EntryNames = string.Empty;
                    EntryNames = JsonSerializer.Deserialize<string>(serializedList) ?? string.Empty;
                }
                catch (JsonException ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            }
        }

        private void PopulateChartDatasets()
        {
            DatasetNames = [];
            EData = [];
            JData = [];
            foreach (var entry in Entries)
            {
                DatasetNames = DatasetNames.Append(entry.Name).ToArray();
                EData = EData.Append(entry.E).ToArray();
                JData = JData.Append(entry.J).ToArray();
            }
        }

        public async Task DrawMultipleCVCharts()
        {
            await _jsRuntime.InvokeVoidAsync("drawMultipleCyclicVoltammogram", ChartId, DatasetNames, JData, EData);
        }

        public async Task UpdateMultipleCVCharts()
        {
            await _jsRuntime.InvokeVoidAsync("updateMultipleCyclicVoltammogram", ChartId, DatasetNames, JData, EData);
        }

        public async Task DeleteMultipleCVCharts()
        {
            await _jsRuntime.InvokeVoidAsync("deleteCyclicVoltammogram", "multipleCharts");
        }

        public string GenerateRandomId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int idLength = 15;

            Random random = new();
            StringBuilder idBuilder = new(idLength);

            for (int i = 0; i < idLength; i++)
            {
                int randomIndex = random.Next(chars.Length);
                idBuilder.Append(chars[randomIndex]);
            }
            return idBuilder.ToString();
        }
    }
}
