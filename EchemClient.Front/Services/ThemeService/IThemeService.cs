namespace EchemClient.Front.Services.ThemeService
{
    public interface IThemeService
    {
        event Action ThemeChanged;
        Task SetTheme(bool isDarkTheme);
        Task<bool> GetTheme();
    }
}
