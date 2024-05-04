using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class Messaging : ContentPage
{
    public Messaging(Messaging_VM vm)
    { 
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        BindingContext = vm;
    }
}