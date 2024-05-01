using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new MainPage_VM();
        InitializeComponent();
	}
}