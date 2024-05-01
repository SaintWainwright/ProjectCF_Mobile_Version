using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class WriteMessage : ContentPage
{
	public WriteMessage(WriteMessage_VM vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}