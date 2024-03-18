using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Worktime : ContentPage
{
	public Worktime()
	{
		InitializeComponent();
		BindingContext = new Worktime_VM();
	}
}