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
            CurrentEmployee = employee_Services.InitializeCurrentEmployee();
        }
        private readonly Employee_Services employee_Services;
    }
}
