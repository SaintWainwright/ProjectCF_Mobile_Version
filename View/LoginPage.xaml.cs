using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new LoginPage_VM();
        InitializeComponent();
	}
}