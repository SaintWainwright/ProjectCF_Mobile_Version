using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class WriteMessage : ContentPage
{
	public WriteMessage(WriteMessage_VM vm)
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as WriteMessage_VM).OnAppearing();
    }
}