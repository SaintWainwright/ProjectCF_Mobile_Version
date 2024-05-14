using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewMessage : ContentPage
{
    public ViewMessage(Message value)
    {
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        this.BindingContext = new ViewMessage_VM(value);
        
    }
    public ViewMessage(ViewMessage_VM vm)
	{
        Application.Current.UserAppTheme = AppTheme.Light;
		InitializeComponent();
        BindingContext = vm;
    }
}