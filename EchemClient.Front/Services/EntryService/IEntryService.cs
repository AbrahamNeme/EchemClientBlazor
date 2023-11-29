using EchemClient.Front.Models;

namespace EchemClient.Front.Services.EntryService
{
    public interface IEntryService
    {
        Task<List<CVEntry>> GetAllCVEntriesAsync();
        Task<List<CVEntry>> GetCVEntriesByMaterialAsync(string material);
        Task<CVEntry> GetCVEntryByNameAsync(string name);
    }
}
