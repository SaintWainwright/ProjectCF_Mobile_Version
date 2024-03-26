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
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class LandingPage_VM : MainViewModel
    {
        public LandingPage_VM()
        {
            employee_Services = new Employee_Services();
            
        }
        private readonly Employee_Services employee_Services;
        private string _EmployeeID;
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); InitializeCurrentEmployee();
            }
        }
        private Employee _CurrentEmployee;
        public Employee CurrentEmployee
        {
            get { return _CurrentEmployee; }
            set { _CurrentEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(_CurrentEmployee)); }
        }
        private void InitializeCurrentEmployee()
        {
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (EmployeeID == employee.EmployeeID)
                {
                    CurrentEmployee = employee;
                }
            }
        }
        private void GoToViewSalary()
        {
            Shell.Current.GoToAsync($"{nameof(ViewSalary)}?id={EmployeeID}");
        }
        public ICommand GoToViewSalaryCommand => new Command(GoToViewSalary);
        private void GoToViewProfile()
        {
            Shell.Current.GoToAsync($"{nameof(ViewProfile)}?id={EmployeeID}");
        }
        public ICommand GoToViewProfileCommand => new Command(GoToViewProfile);
        private void GoToWorktime()
        {
            Shell.Current.GoToAsync($"{nameof(Worktime)}?id={EmployeeID}");
        }
        public ICommand GoToWorktimeCommand => new Command(GoToWorktime);
        private void GoToMessaging()
        {
            Shell.Current.GoToAsync($"{nameof(Messaging)}?id={EmployeeID}");
        }
        public ICommand GoToMessagingCommand => new Command(GoToMessaging);
    }
}
