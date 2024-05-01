using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPage_VM vm)
	{ 
        InitializeComponent();
        BindingContext = vm;
    }
}