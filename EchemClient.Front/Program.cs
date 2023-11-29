using Blazored.LocalStorage;
using CommunityToolkit.Mvvm.Messaging;
using EchemClient.Front;
using EchemClient.Front.Services.EntryService;
using EchemClient.Front.Services.ThemeService;
using EchemClient.Front.ViewModels.EntriesSearch;
using EchemClient.Front.ViewModels.Home;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:8000/") });
builder.Services.AddMudServices();
builder.Services.AddScoped<MudThemeProvider>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IMessenger, WeakReferenceMessenger>();
builder.Services.AddScoped<IHomeViewModel, HomeViewModel>();
builder.Services.AddScoped<IEntriesSearchViewModel, EntriesSearchViewModel>();
builder.Services.AddScoped<IEntryService, EntryService>();


await builder.Build().RunAsync();