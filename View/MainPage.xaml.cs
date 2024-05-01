using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainPage_VM vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}