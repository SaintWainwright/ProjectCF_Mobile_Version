using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class WorkTimeOut : ContentPage
{
	public WorkTimeOut()
	{
		InitializeComponent();
		BindingContext = new WorkTimeOut_VM();
	}
}