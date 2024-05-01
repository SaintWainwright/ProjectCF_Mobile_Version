using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.Model
{
    public partial class Employee : ObservableObject
    {
        [ObservableProperty]
        private string employeeID;
        [ObservableProperty]
        private string fullName;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string contactNumber;
        [ObservableProperty]
        private string gender;
        [ObservableProperty]
        private Byte[] image;
        [ObservableProperty]
        private DateTime hoursWorked;
        [ObservableProperty]
        private string activtiyStatus = "Inactive";
        [ObservableProperty]
        private string jobPosition;
        [ObservableProperty]
        private DateTime dateJoined = DateTime.Today;
        [ObservableProperty]
        private DateTime birthDate = DateTime.Today;
        [ObservableProperty]
        private string country;
        [ObservableProperty]
        private string homeAddress;
        [ObservableProperty]
        private string provincialAddress;
        [ObservableProperty]
        private double salaryGrade;
        [ObservableProperty]
        private ObservableCollection<Employee_Worktimes> worktimes = [];
    }
}
