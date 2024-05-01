using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new LandingPage_VM();
        InitializeComponent();
	}
}