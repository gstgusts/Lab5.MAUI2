using CommunityToolkit.Maui;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;
using MauiApp2.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiApp2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddScoped<IStudentApiClient, StudentApiClient>();
            builder.Services.AddScoped<IDataRepository, ApiDataRepository>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddScoped<GradesPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<GradesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
