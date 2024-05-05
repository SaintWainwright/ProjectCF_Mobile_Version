using ProjectCF_Mobile_Version.ViewModel;
using System.ComponentModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewSalary : ContentPage, INotifyPropertyChanged
{
	public ViewSalary(ViewSalary_VM vm)
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        BindingContext = vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ViewSalary_VM).OnAppearing();
    }
}