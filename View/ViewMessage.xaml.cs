using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewMessage : ContentPage
{
	public ViewMessage()
	{
		BindingContext = new ViewMessage_VM();
		InitializeComponent();
	}
}