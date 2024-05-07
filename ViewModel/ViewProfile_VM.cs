using CommunityToolkit.Mvvm.ComponentModel;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewProfile_VM : ObservableObject
    {
        [ObservableProperty]
        private Employee currentEmployee;
        public void OnAppearing() => CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
    }
}
