using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        BindingContext = new MainPage_VM();
        InitializeComponent();
	}
}