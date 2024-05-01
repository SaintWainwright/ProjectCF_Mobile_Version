using Microsoft.Extensions.Logging;
using ProjectCF_Mobile_Version.View;
using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version
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
            builder.Services.AddSingleton<Messaging>();
            builder.Services.AddSingleton<Messaging_VM>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
