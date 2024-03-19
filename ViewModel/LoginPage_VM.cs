using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class LoginPage_VM : MainViewModel
    {
        public LoginPage_VM()
        {
            employee_Services = new Employee_Services();
        }
        private readonly Employee_Services employee_Services;
        private void GoToLandingPage()
        {
            Shell.Current.GoToAsync(nameof(LandingPage), false);
        }
        public ICommand GoToLandingPageCommand => new Command(GoToLandingPage);

        private void GoToMainPage()
        {
            Shell.Current.GoToAsync(nameof(MainPage), false);
        }
        public ICommand GoToMainPageCommand => new Command(GoToMainPage);
        private string _EmployeeIDEntry;
        public string EmployeeIDEntry
        {
            get { return _EmployeeIDEntry; }
            set
            {
                _EmployeeIDEntry = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeIDEntry));
            }
        }
        private string _EmployeePassword;
        public string EmployeePassword
        {
            get { return _EmployeePassword; }
            set
            {
                _EmployeePassword = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeePassword));
            }
        }
        private bool IDExisting()
        {
            bool existing = false;
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (EmployeeIDEntry == employee.EmployeeID && EmployeePassword == employee.Password)
                {
                    existing = true;
                }
            }
            return existing;
        }
        private void SignIn()
        {
            string EmployeeID = string.Empty;
            if (IDExisting())
            {
                Shell.Current.DisplayAlert("Login Sucess", "Logging into your account...", "Okay");
                EmployeeID = EmployeeIDEntry;
                Shell.Current.GoToAsync($"{nameof(LandingPage)}?id={EmployeeID}");
            }
            else
            {
                Shell.Current.DisplayAlert("Account Not Found", "Your Account was not found in the database", "Okay");
            }
        }
        public ICommand SignInCommand => new Command(SignIn);
    }
}
