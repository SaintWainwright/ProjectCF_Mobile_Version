using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class WorkTimeIn : ContentPage
{
	public WorkTimeIn()
	{
		InitializeComponent();
		BindingContext = new WorkTimeIn_VM();
	}
}