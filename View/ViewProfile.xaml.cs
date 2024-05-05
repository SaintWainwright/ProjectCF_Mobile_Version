using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewProfile : ContentPage
{
	public ViewProfile(ViewProfile_VM vm)
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ViewProfile_VM).OnAppearing();
    }
}