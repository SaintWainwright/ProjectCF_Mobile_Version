using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class LandingPage_VM : ObservableObject
    {
        public LandingPage_VM()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
        [ObservableProperty]
        private Employee currentEmployee;

        [RelayCommand]
        private void GoToViewSalary()
        {
            Shell.Current.GoToAsync(nameof(ViewSalary), false);
        }
        [RelayCommand]
        private void GoToViewProfile()
        {
            Shell.Current.GoToAsync(nameof(ViewProfile), false);
        }
        [RelayCommand]
        private void GoToWorktime()
        {
            Shell.Current.GoToAsync(nameof(Worktime),false);
        }
        [RelayCommand]
        private void GoToMessaging()
        {
            Shell.Current.GoToAsync(nameof(Messaging), false);
        }
    }
}
