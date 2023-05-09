﻿using Microsoft.Extensions.Logging;

using The49.Maui.BottomSheet.ViewModels;
using The49.Maui.BottomSheet.Views;
using The49.Maui.Insets;

namespace The49.Maui.BottomSheet;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseInsets()
            .UseBottomSheet()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterViews()
            .RegisterViewModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<HomePage>();
        appBuilder.Services.AddSingleton<HelpPage>();
        return appBuilder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<HomePageViewModel>();
        return appBuilder;
    }
}
