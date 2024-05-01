using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewMessage : ContentPage
{
	public ViewMessage(ViewMessage_VM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}