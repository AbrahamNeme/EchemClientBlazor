using EchemClient.Front.Models;
using System.Net.Http.Json;

namespace EchemClient.Front.Services.EntryService
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient _httpClient;
        public EntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CVEntry>> GetAllCVEntriesAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<CVEntry>>("api/all/");
                if (response != null)
                {
                    return response;
                }
                else { return []; }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }

        public async Task<List<CVEntry>> GetCVEntriesByMaterialAsync(string material)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<CVEntry>>($"api/entrybymaterial/{material}/");
                if (response != null)
                {
                    return response;
                }
                else { return []; }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }

        public async Task<CVEntry> GetCVEntryByNameAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CVEntry>($"api/entrybyname/{name}/");
                if (response != null)
                {
                    return response;
                }
                else { return new CVEntry(); }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new CVEntry();
            }
        }
    }
}
