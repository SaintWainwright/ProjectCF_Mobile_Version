using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewProfile_VM : LandingPage_VM
    {
        public ViewProfile_VM()
        {
            employee_Services = new Employee_Services();
            InitializeCurrentEmployee();
        }
        private readonly Employee_Services employee_Services;
        private string currentEmployeeBirthday;
        public string CurrentEmployeeBirthday
        {
            get { return currentEmployeeBirthday; }
            set { currentEmployeeBirthday = value; OnPropertyChanged(); OnPropertyChanged(nameof(currentEmployeeBirthday)); }
        }
        private string currentEmployeeDateJoined;
        public string CurrentEmployeeDateJoined
        {
            get { return currentEmployeeDateJoined; }
            set { currentEmployeeDateJoined = value; OnPropertyChanged(); OnPropertyChanged(nameof(currentEmployeeDateJoined)); }
        }

    }
}
