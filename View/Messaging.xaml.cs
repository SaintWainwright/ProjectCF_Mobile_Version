using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Messaging : ContentPage
{
	public Messaging()
	{
		InitializeComponent();
		BindingContext = new Messaging_VM();
	}
}