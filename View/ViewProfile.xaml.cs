using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewProfile : ContentPage
{
	public ViewProfile()
	{
		InitializeComponent();
		BindingContext = new ViewProfile_VM();
	}
}