using ProjectCF_Mobile_Version.ViewModel;
using System.ComponentModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewSalary : ContentPage, INotifyPropertyChanged
{
	public ViewSalary()
	{
        BindingContext = new ViewSalary_VM();
        InitializeComponent();
	}
}