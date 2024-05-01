using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewMessage : ContentPage
{
	public ViewMessage()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new ViewMessage_VM();
		InitializeComponent();
	}
}