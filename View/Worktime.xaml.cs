using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Worktime : ContentPage
{
	public Worktime(Worktime_VM vm)
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        BindingContext = vm;
    }
    /*protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as Worktime).OnAppearing();
    }*/
}