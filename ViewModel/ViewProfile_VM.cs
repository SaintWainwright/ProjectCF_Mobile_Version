using ProjectCF_Mobile_Version.Services;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewProfile_VM : LandingPage_VM
    {
        private readonly Employee_Services employee_Services;
        public ViewProfile_VM()
        {
            employee_Services = new Employee_Services();
            CurrentEmployee = employee_Services.InitializeCurrentEmployee();
        }
    }
}
