using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Messaging : ContentPage
{
	public Messaging()
	{
        BindingContext = new Messaging_VM();
        InitializeComponent();
	}
}