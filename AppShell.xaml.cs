using ProjectCF_Mobile_Version.View;

namespace ProjectCF_Mobile_Version
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
