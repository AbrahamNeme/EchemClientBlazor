using EchemClient.Front.Models;

namespace EchemClient.Front.ViewModels.Home
{
    public interface IHomeViewModel
    {
        List<Element> Elements { get; }
        Element HoveredElement { get; set; }
        string SearchString { get; set; }

        List<Element> GetSelectedElements();
    }
}
