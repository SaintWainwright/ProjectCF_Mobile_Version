using ProjectCF_Mobile_Version.Model;
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
    public partial class LandingPage_VM : MainViewModel
    {
        public LandingPage_VM()
        {
            employee_Services = new Employee_Services();
            InitializeCurrentEmployee();
        }
        private readonly Employee_Services employee_Services;
        private Employee _CurrentEmployee;
        public Employee CurrentEmployee
        {
            get { return _CurrentEmployee; }
            set { _CurrentEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(_CurrentEmployee)); }
        }
        public void InitializeCurrentEmployee()
        {
            string employeeID = Preferences.Get("employeeID", "Unknown");
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (employeeID == employee.EmployeeID)
                {
                    CurrentEmployee = employee;
                }
            }
        }
        private void GoToViewSalary()
        {
            Shell.Current.GoToAsync(nameof(ViewSalary), false);
        }
        public ICommand GoToViewSalaryCommand => new Command(GoToViewSalary);
        private void GoToViewProfile()
        {
            Shell.Current.GoToAsync(nameof(ViewProfile), false);
        }
        public ICommand GoToViewProfileCommand => new Command(GoToViewProfile);
        private void GoToWorktime()
        {
            Shell.Current.GoToAsync(nameof(Worktime),false);
        }
        public ICommand GoToWorktimeCommand => new Command(GoToWorktime);
        private void GoToMessaging()
        {
            Shell.Current.GoToAsync(nameof(Messaging), false);
        }
        public ICommand GoToMessagingCommand => new Command(GoToMessaging);
    }
}
