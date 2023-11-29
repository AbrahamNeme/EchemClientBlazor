using Blazored.LocalStorage;

namespace EchemClient.Front.Services.ThemeService
{
    public class ThemeService : IThemeService
    {
        private readonly ILocalStorageService _localStorage;

        public event Action ThemeChanged;

        public ThemeService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            ThemeChanged = new Action(() => { });
        }
        public async Task SetTheme(bool isDarkTheme)
        {
            await _localStorage.SetItemAsync("Theme", isDarkTheme);
            ThemeChanged.Invoke();
        }

        public async Task<bool> GetTheme()
        {
            bool isDarkTheme = await _localStorage.GetItemAsync<bool>("Theme");
            return isDarkTheme;
        }
    }
}
