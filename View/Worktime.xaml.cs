using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Worktime : ContentPage
{
	public Worktime()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        BindingContext = new Worktime_VM();
        InitializeComponent();
	}
}