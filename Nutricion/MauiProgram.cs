using Microsoft.Extensions.Logging;

namespace Nutricion
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string path = FileAccessHelper.GetLocationFile("imc.db3");
            builder.Services.AddSingleton<Repository>(
                s => ActivatorUtilities.CreateInstance<Repository>(s, path));
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}