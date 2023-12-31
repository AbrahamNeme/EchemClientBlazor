﻿using CommunityToolkit.Mvvm.ComponentModel;
using EchemClient.Front.Models;
using EchemClient.Front.Services.ElementService;
using EchemClient.Front.Services.EntryService;
using EchemClient.Front.Services.SessionStorageService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;

namespace EchemClient.Front.ViewModels.EntriesSearch
{
    public partial class EntriesSearchViewModel: ObservableRecipient, IEntriesSearchViewModel
    {
        [ObservableProperty]
        public List<Element> _elements = [];

        [ObservableProperty]
        public List<CVEntry> _entries = [];

        [ObservableProperty]
        public HashSet<CVEntry> _selectedEntries = [];

        private readonly IJSRuntime _jsRuntime;
        private readonly IEntryService _entryService;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly IElementService _elementService;
        private readonly NavigationManager _navigationManager;

        public EntriesSearchViewModel(IJSRuntime jsRuntime, IEntryService entryService, ISessionStorageService sessionStorageService, 
            IElementService elementService, NavigationManager navigationManager) 
        {
            _jsRuntime = jsRuntime;
            _entryService = entryService;
            _sessionStorageService = sessionStorageService;
            _elementService = elementService;
            _navigationManager = navigationManager;
        }

        public async Task OnInitializedAsync()
        {
            Entries.Clear();
            if (Elements.Count < 1)
            {
                Elements = _elementService.FromStringToList(await _sessionStorageService.GetItem("selectedElements"));
            }
            foreach (var element in Elements) 
            {
                Entries.AddRange(await _entryService.GetCVEntriesByMaterialAsync(element.Symbol));
            }
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
                    Elements = JsonSerializer.Deserialize<List<Element>>(serializedList) ?? [];
                }
                catch (JsonException ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
            }
        }

        public void GoToEntryDashboard(string entryName)
        {
            var serializedName = JsonSerializer.Serialize(entryName);
            _navigationManager.NavigateTo($"/entry-dashboard?name={Uri.EscapeDataString(serializedName)}");
        }

        public void GoToMultiplot()
        {
            StringBuilder entryNames = new();
            foreach (var entry in SelectedEntries)
            {
                entryNames.Append($"{entry.Name},");
            }
            entryNames.Length -= 1;
            var serializedList = JsonSerializer.Serialize(entryNames.ToString());
            SelectedEntries.Clear();
            _navigationManager.NavigateTo($"/multiplot?list={Uri.EscapeDataString(serializedList)}", forceLoad: true);
        }

        public bool IsMultiplotDisabled()
        {
            if (SelectedEntries.Count > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
