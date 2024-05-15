using Microsoft.Extensions.Logging;
using ProjectCF_Mobile_Version.Services;
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
            builder.Services.AddTransient<LandingPage>();
            builder.Services.AddTransient<LandingPage_VM>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPage_VM>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPage_VM>();
            builder.Services.AddTransient<Messaging>();
            builder.Services.AddTransient<Messaging_VM>();
            builder.Services.AddTransient<ViewMessage>();
            builder.Services.AddTransient<ViewMessage_VM>();
            builder.Services.AddTransient<ViewProfile>();
            builder.Services.AddTransient<ViewProfile_VM>();
            builder.Services.AddTransient<ViewSalary>();
            builder.Services.AddTransient<ViewSalary_VM>();
            builder.Services.AddTransient<Worktime>();
            builder.Services.AddTransient<Worktime_VM>();
            builder.Services.AddTransient<WriteMessage>();
            builder.Services.AddTransient<WriteMessage_VM>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
