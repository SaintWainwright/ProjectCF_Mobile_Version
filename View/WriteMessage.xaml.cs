using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class WriteMessage : ContentPage
{
	public WriteMessage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new WriteMessage_VM();
        InitializeComponent();
	}
}