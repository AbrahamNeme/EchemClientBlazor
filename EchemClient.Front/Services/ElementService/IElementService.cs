using EchemClient.Front.Models;

namespace EchemClient.Front.Services.ElementService
{
    public interface IElementService
    {
        List<Element> Elements { get; }

        Element GetElementBySymbol(string symbol);
    }
}
