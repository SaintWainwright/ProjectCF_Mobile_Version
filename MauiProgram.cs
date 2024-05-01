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
            builder.Services.AddSingleton<LandingPage>();
            builder.Services.AddSingleton<LandingPage_VM>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPage_VM>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPage_VM>();
            builder.Services.AddSingleton<Messaging>();
            builder.Services.AddSingleton<Messaging_VM>();
            builder.Services.AddSingleton<ViewMessage>();
            builder.Services.AddSingleton<ViewMessage_VM>();
            builder.Services.AddSingleton<ViewProfile>();
            builder.Services.AddSingleton<ViewProfile_VM>();
            builder.Services.AddSingleton<ViewSalary>();
            builder.Services.AddSingleton<ViewSalary_VM>();
            builder.Services.AddSingleton<Worktime>();
            builder.Services.AddSingleton<Worktime_VM>();
            builder.Services.AddSingleton<WriteMessage>();
            builder.Services.AddSingleton<WriteMessage_VM>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
