using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewProfile : ContentPage
{
	public ViewProfile()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new ViewProfile_VM();
        InitializeComponent();
	}
}