﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Mopups.Hosting;

namespace PersonasApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("kindergarten.ttf", "KinderGarten");
            }).UseMauiCommunityToolkit().UseFFImageLoading().ConfigureMopups();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}