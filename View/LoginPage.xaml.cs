using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        BindingContext = new LoginPage_VM();
        InitializeComponent();
	}
}