using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using EchemClient.Front.Models;
using EchemClient.Front.Services.ElementService;
using EchemClient.Front.Services.SessionStorageService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Interfaces;
using System.Text.Json;
using System.Timers;

namespace EchemClient.Front.ViewModels.Home
{
    public partial class HomeViewModel : ObservableObject, IHomeViewModel
    {
        [ObservableProperty]
        public List<Element> _elements = [];

        [ObservableProperty]
        public Element _hoveredElement = new("H", "Hydrogen", "reactive non-metals", 1, 1.008);

        [ObservableProperty]
        public string _searchString = string.Empty;

        private readonly IElementService _elementService;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly NavigationManager _navigationManager;

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HomeViewModel() { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public HomeViewModel( IElementService elementService, ISessionStorageService sessionStorageService, NavigationManager navigationManager) 
        {
            _elementService = elementService;
            _sessionStorageService = sessionStorageService;
            _navigationManager = navigationManager;
            _elements = _elementService.Elements;
        }

        public void SendElements()
        {
            _sessionStorageService.SetItem("selectedElements", SearchString);
            var serializedList = JsonSerializer.Serialize(_elementService.FromStringToList(SearchString));
            SearchString = "";
            _navigationManager.NavigateTo($"/entries-search?list={Uri.EscapeDataString(serializedList)}");
        }
    }
}
