using ProjectCF_Mobile_Version.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Model
{
    public class Employee : MainViewModel
    {
        private string? _EmployeeID;
        private string? fullName;
        private string? email;
        private string? password;
        private string? contactNumber;
        private string? gender;
        private Byte[]? image;
        private DateTime hoursWorked;
        private string activtiyStatus = "Inactive";
        private string? jobPosition;
        private DateTime dateJoined = DateTime.Today;
        private DateTime birthDate = DateTime.Today;
        private string? country;
        private string? homeAddress;
        private string? provincialAddress;
        private double salaryGrade;
        private ObservableCollection<Employee_Worktimes> worktimes = new();

        public ObservableCollection<Employee_Worktimes> Worktimes
        {
            get { return worktimes; }
            set { worktimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(worktimes)); }
        }

        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged(); OnPropertyChanged(nameof(fullName)); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); OnPropertyChanged(nameof(email)); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(password)); }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; OnPropertyChanged(); OnPropertyChanged(nameof(contactNumber)); }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); OnPropertyChanged(nameof(gender)); }
        }
        public Byte[] Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); OnPropertyChanged(nameof(image)); }
        }
        public DateTime HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(hoursWorked)); }
        }
        public string ActivtiyStatus
        {
            get { return activtiyStatus; }
            set { activtiyStatus = value; OnPropertyChanged(); OnPropertyChanged(nameof(activtiyStatus)); }
        }
        public string JobPosition
        {
            get { return jobPosition; }
            set { jobPosition = value; OnPropertyChanged(); OnPropertyChanged(nameof(jobPosition)); }
        }
        public DateTime DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = value; OnPropertyChanged(); OnPropertyChanged(nameof(dateJoined)); }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; OnPropertyChanged(); OnPropertyChanged(nameof(birthDate)); }
        }
        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged(); OnPropertyChanged(nameof(country)); }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; OnPropertyChanged(); OnPropertyChanged(nameof(homeAddress)); }
        }
        public string ProvincialAddress
        {
            get { return provincialAddress; }
            set { provincialAddress = value; OnPropertyChanged(); OnPropertyChanged(nameof(provincialAddress)); }
        }

        public double SalaryGrade
        {
            get { return salaryGrade; }
            set { salaryGrade = value; OnPropertyChanged(); OnPropertyChanged(nameof(salaryGrade)); }
        }
    }
}
