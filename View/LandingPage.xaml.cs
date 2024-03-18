using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
		BindingContext = new LandingPage_VM();
	}
}