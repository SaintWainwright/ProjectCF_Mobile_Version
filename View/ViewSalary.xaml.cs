using ProjectCF_Mobile_Version.ViewModel;

namespace ProjectCF_Mobile_Version.View;

public partial class ViewSalary : ContentPage
{
	public ViewSalary()
	{
        BindingContext = new ViewSalary_VM();
        InitializeComponent();
	}
}