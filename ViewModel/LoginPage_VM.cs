using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class LoginPage_VM : ObservableObject
    {
        public LoginPage_VM()
        {
            Preferences.Default.Remove("employeeID");
        }
        [ObservableProperty]
        private string employeeIDEntry;
        [ObservableProperty]
        private string employeePassword;
        private bool IDExisting()
        {
            bool existing = false;
            foreach (var employee in Employee_Services.GetEmployees())
            {
                if (EmployeeIDEntry == employee.EmployeeID && EmployeePassword == employee.Password)
                {
                    return true;
                }
            }
            return existing;
        }
        [RelayCommand]
        private void SignIn()
        {
            Preferences.Default.Remove("employeeID");
            if (IDExisting())
            {
                Shell.Current.DisplayAlert("Login Sucess", "Logging into your account...", "Okay");
                Preferences.Default.Set("employeeID", EmployeeIDEntry);
                Shell.Current.GoToAsync(nameof(LandingPage), false);
            }
            else
            {
                Shell.Current.DisplayAlert("Account Not Found", "Your Account was not found in the database", "Okay");
            }
        }
        public void OnAppearing()
        {
            Preferences.Default.Remove("employeeID");
        }
    }
}
