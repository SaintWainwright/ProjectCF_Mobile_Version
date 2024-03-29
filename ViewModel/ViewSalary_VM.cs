using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class ViewSalary_VM : MainViewModel
    {

        public ViewSalary_VM()
        {
            employee_Services = new Employee_Services();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            MonthPckr = new ObservableCollection<string>
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            currentMonth = DateOnly.FromDateTime(DateTime.MinValue);
        }

        private readonly Employee_Services employee_Services;
        private TimeSpan totalOvertime;
        private TimeSpan totalLate;
        private TimeSpan totalHoursWorked;
        private String displayTotalOvertime;
        private String displayTotalLate;
        private String displayTotalHoursWorked;
        private double overtimeBonus;
        private double lateDeductions;
        private double temporarySalary;
        private double finalSalary;
        private double totalEarnings;
        private double totalDeductions;
        private double taxes;
        private double pagibig;
        private double philHealth;
        private double sss;
        private string _EmployeeID;
        private DateTime chosenMonth;
        private DateOnly currentMonth;
        private ObservableCollection<string> monthPckr;
        public ObservableCollection<string> MonthPckr
        {
            get { return monthPckr; }
            set { monthPckr = value; OnPropertyChanged(); OnPropertyChanged(nameof(monthPckr)); }
        }
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
        }
        public string DisplayTotalOvertime
        {
            get { return displayTotalOvertime; }
            set { displayTotalOvertime = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalOvertime)); }
        }
        public string DisplayTotalLate
        {
            get { return displayTotalLate; }
            set { displayTotalLate = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalLate)); }
        }
        public string DisplayTotalHoursWorked
        {
            get { return displayTotalHoursWorked; }
            set { displayTotalHoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(displayTotalHoursWorked)); }
        }
        public double OvertimeBonus
        {
            get { return overtimeBonus; }
            set { overtimeBonus = value; OnPropertyChanged(); OnPropertyChanged(nameof(overtimeBonus)); }
        }
        public double LateDeductions
        {
            get { return lateDeductions; }
            set { lateDeductions = value; OnPropertyChanged(); OnPropertyChanged(nameof(lateDeductions)); }
        }
        public double TemporarySalary
        {
            get { return temporarySalary; }
            set { temporarySalary = value; OnPropertyChanged(); OnPropertyChanged(nameof(temporarySalary)); }
        }
        public double FinalSalary
        {
            get { return finalSalary; }
            set { finalSalary = value; OnPropertyChanged(); OnPropertyChanged(nameof(finalSalary)); }
        }
        public TimeSpan TotalOvertime
        {
            get { return totalOvertime; }
            set { totalOvertime = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalOvertime)); }
        }

        public TimeSpan TotalLate
        {
            get { return totalLate; }
            set { totalLate = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalLate)); }
        }
        public TimeSpan TotalHoursWorked
        {
            get { return totalHoursWorked; }
            set { totalHoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalHoursWorked)); }
        }
        public double TotalEarnings
        {
            get { return totalEarnings; }
            set { totalEarnings = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalEarnings)); }
        }
        public double TotalDeductions
        {
            get { return totalDeductions; }
            set { totalDeductions = value; OnPropertyChanged(); OnPropertyChanged(nameof(totalDeductions)); }
        }
        public double Taxes
        {
            get { return taxes; }
            set { taxes = value; OnPropertyChanged(); OnPropertyChanged(nameof(taxes)); }
        }
        public double PagIbig
        {
            get { return pagibig; }
            set { pagibig = value; OnPropertyChanged(); OnPropertyChanged(nameof(pagibig)); }
        }
        public double PhilHealth
        {
            get { return philHealth; }
            set { philHealth = value; OnPropertyChanged(); OnPropertyChanged(nameof(philHealth)); }
        }
        public double SSS
        {
            get { return sss; }
            set { sss = value; OnPropertyChanged(); OnPropertyChanged(nameof(sss)); }
        }
        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                currentEmployee = value; OnPropertyChanged(); OnPropertyChanged(nameof(currentEmployee));
            }
        }
        public void Total()
        {
            foreach (Employee_Worktimes worktimes in CurrentEmployee.Worktimes)
            {
                if(worktimes.Month.Month == 3 && worktimes.Year.Year == 2024)
                {
                    TotalOvertime += worktimes.Overtimes.TimeOfDay;
                    TotalLate += worktimes.Lates.TimeOfDay;
                    TotalHoursWorked += worktimes.HoursWorked.TimeOfDay;
                }
            }
        }
        public ICommand TotalCommand => new Command(Total);
        public void Calculate()
        {
            TotalHoursWorked -= totalOvertime;
            TemporarySalary = CurrentEmployee.SalaryGrade * totalHoursWorked.TotalHours;
            OvertimeBonus = (CurrentEmployee.SalaryGrade + 2.0) * totalOvertime.TotalHours;
            LateDeductions = (CurrentEmployee.SalaryGrade + 5.0) * totalLate.TotalHours;
            Taxes = temporarySalary * 0.0116;
            PagIbig = temporarySalary * 0.03;
            PhilHealth = temporarySalary * 0.04;
            SSS = temporarySalary * 0.045;
            TotalEarnings = temporarySalary + overtimeBonus;
            TotalDeductions = lateDeductions + taxes + pagibig + philHealth + sss;
            FinalSalary = TotalEarnings - TotalDeductions;
        }
        public ICommand CalculateCommand => new Command(Calculate);
        public void SetDisplayValues()
        {
            DisplayTotalOvertime = TotalOvertime.TotalHours.ToString();
            DisplayTotalLate = TotalLate.TotalHours.ToString();
            DisplayTotalHoursWorked = TotalHoursWorked.TotalHours.ToString();
        }
        public ICommand SetDisplayValuesCommand => new Command(SetDisplayValues);
        public void InitializeCurrentEmployee()
        {
            foreach (var employee in employee_Services.GetEmployees())
            {
                if (EmployeeID == employee.EmployeeID)
                {
                    CurrentEmployee = employee;
                }
            }
        }
        public void ResetValues()
        {
            TemporarySalary = 0;
            TotalOvertime = TimeSpan.MinValue;
            TotalLate = TimeSpan.MinValue;
            TotalEarnings = 0;
            TotalDeductions = 0;
            FinalSalary = 0;
        }
        private void PickerMonth_SelectedIndexChanged()
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            MonthPckr.Clear();
            int years = DateTime.Now.Year;

            if (selectedIndex == 1)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 2)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(1);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 3)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(2);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 4)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(3);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 5)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(4);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 6)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(5);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if (selectedIndex == 7)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(6);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if(selectedIndex == 8)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(7);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if(selectedIndex == 9)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(8);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if(selectedIndex == 10)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(9);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if(selectedIndex == 11)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(10);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else if(selectedIndex == 12)
            {
                ResetValues();
                chosenMonth = DateTime.MinValue;
                chosenMonth.AddYears(years);
                chosenMonth.AddMonths(11);
                InitializeCurrentEmployee(); Total(); Calculate(); SetDisplayValues();
            }
            else
            {
                return;
            }

        }
        public ICommand PickMonthCommand => new Command(PickerMonth_SelectedIndexChanged);
    }
}
