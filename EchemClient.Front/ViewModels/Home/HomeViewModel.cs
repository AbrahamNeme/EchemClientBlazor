using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using EchemClient.Front.Models;
using EchemClient.Front.Services.ElementService;
using Microsoft.JSInterop;
using MudBlazor.Interfaces;
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

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HomeViewModel() { }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public HomeViewModel( IElementService elementService) 
        {
            _elementService = elementService;
            _elements = _elementService.Elements;
        }

        public List<Element> GetSelectedElements()
        {
            List<string> stringElements = SearchString.Split(' ').ToList();
            List<Element> selectedElements = [];

            if (stringElements.Count > 0)
            {
                foreach (string element in stringElements)
                {
                    selectedElements.AddRange(Elements.Where(e => e.Symbol == element).ToList());
                }
            }
            return selectedElements;
        }
    }
}
