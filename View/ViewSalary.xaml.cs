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
}