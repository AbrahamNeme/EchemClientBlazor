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
        public string _chartId = string.Empty;

        [ObservableProperty]
        public bool _referenceNormalization;

        [ObservableProperty]
        public bool _scanRateNormalization;

        [ObservableProperty]
        public bool _electrolyteConcentrationNormalization;

        [ObservableProperty]
        public string _selectedReference = string.Empty;

        [ObservableProperty]
        public string _legendReference = string.Empty;

        [ObservableProperty]
        public string _selectedScanRate = string.Empty;

        [ObservableProperty]
        public string _jUnits = "A / m2";

        [ObservableProperty]
        public Dictionary<string, double> _refs = new()
        {
            { "Ag/AgCl", 4.637 },      
            { "Ag/AgCl-sat", 4.637 },
            { "Ag/AgCl_3M", 4.637 },
            { "Hg/HgO/0.1 M NaOH", 4.9 },  // Dummy data
            { "RHE", 4.44 },  // Dummy Data
            { "SCE", 4.688 },
            { "wire", 5.55 },  // Dummy Data
            { "SHE", 4.44 },
            { "NCE", 4.720 }
        };

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

        public void NormalizeData()
        {
            PopulateChartDatasets();
            if (ReferenceNormalization)
            {
                NormalizeByReference();
            }
            else { LegendReference = string.Empty; }
            if (ScanRateNormalization)
            {
                NormalizeByScanRate();
            }
            else { JUnits = "A / m2"; }
            if (ElectrolyteConcentrationNormalization)
            {
                NormalizeByElectrolyteConcentration();
            }
        }
        private void NormalizeByReference()
        {
            if (SelectedReference == string.Empty || SelectedReference == null) { SelectedReference = "SHE"; }
            for (int i = 0; i < Entries.Count; i++)
            {
                double deltaRef = Refs[Entries[i].Ref_Electrode.Type] - Refs[SelectedReference];
                EData[i] = EData[i].Select(x => x + deltaRef).ToArray();
            }
            LegendReference = SelectedReference;
        }

        private void NormalizeByScanRate()
        {
            double refScanRate = new();
            if (SelectedScanRate == string.Empty || SelectedScanRate == null) { refScanRate = 0.05; SelectedScanRate = "0.05"; }
            else {
                try { refScanRate = Convert.ToDouble(SelectedScanRate); }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    refScanRate = 0.05;
                }
            }
            for (int i = 0; i < Entries.Count; i++)
            {
                double entryScanRate = new();
                if (Entries[i].ScanRate_unit.Contains("mV")) { entryScanRate = Entries[i].ScanRate_value / 1000.0; }
                else { entryScanRate = Entries[i].ScanRate_value; }
                double scanRateRatio = entryScanRate / refScanRate;
                JData[i] = JData[i].Select(x => x / scanRateRatio).ToArray();

                string[] units = Entries[i].J_Unit.Split('/');    // Normally A / m2
                if (units[0] == "A ") { JData[i] = JData[i].Select(x => x * 1e6).ToArray(); }
                if (units[1] == " m2") { JData[i] = JData[i].Select(x => x / 1e4).ToArray(); }
            }
            JUnits = "μA / cm2";
        }

        private void NormalizeByElectrolyteConcentration()
        {
            return;
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
