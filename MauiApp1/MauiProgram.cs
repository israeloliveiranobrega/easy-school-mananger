using CommunityToolkit.Maui;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.View;
using MauiApp1.MVVM.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

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

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddTransient<HelioKickerView>();
            builder.Services.AddTransient<HelioKickerViewModel>();
            builder.Services.AddTransient<ContadorDeKikadasModel>();
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            ServiceProvider = app.Services;
            return builder.Build();
        }
    }
}
