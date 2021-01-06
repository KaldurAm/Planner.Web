using System;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Planner.UI.RestServices;
using Planner.UI.Statics;
using Planner.UI.Util;

namespace Planner.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<BuildingObjectService>();
            builder.Services.AddScoped<DistrictService>();
            builder.Services.AddScoped<CurrencyService>();
            builder.Services.AddScoped<PropertyService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<TaskService>();
            builder.Services.AddScoped<Radzen.DialogService>();
            builder.Services.AddScoped<Radzen.NotificationService>();
            builder.Services.AddScoped<TaskEditState>();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.Configuration["baseUrl"])
                });

            await builder.Build().RunAsync();
        }
    }
}
