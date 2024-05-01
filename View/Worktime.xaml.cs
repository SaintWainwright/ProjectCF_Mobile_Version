using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Worktime : ContentPage
{
	public Worktime(Worktime_VM vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}