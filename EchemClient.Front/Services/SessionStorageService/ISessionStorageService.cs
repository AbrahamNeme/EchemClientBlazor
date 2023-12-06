namespace EchemClient.Front.Services.SessionStorageService
{
    public interface ISessionStorageService
    {
        Task SetItem(string key, string value);
        Task<string> GetItem(string key);
        Task RemoveItem(string key);
    }
}
