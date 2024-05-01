using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewProfile : ContentPage
{
	public ViewProfile(ViewProfile_VM vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}
}