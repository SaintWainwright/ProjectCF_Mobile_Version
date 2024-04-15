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
    public partial class ViewSalary_VM : LandingPage_VM
    {
        public ViewSalary_VM()
        {
            employee_Services = new Employee_Services();
            InitializeCurrentEmployee();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            MonthPicker = new ObservableCollection<string>
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
        private ObservableCollection<string> monthPicker;
        public ObservableCollection<string> MonthPicker
        {
            get { return monthPicker; }
            set { monthPicker = value; OnPropertyChanged(); OnPropertyChanged(nameof(monthPicker)); }
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
        private void Total()
        {
            foreach (Employee_Worktimes worktimes in CurrentEmployee.Worktimes)
            {
                if(worktimes.Month.Month == chosenMonth.Month && worktimes.Year.Year == chosenMonth.Year)
                {
                    TotalOvertime += worktimes.Overtimes.TimeOfDay;
                    TotalLate += worktimes.Lates.TimeOfDay;
                    TotalHoursWorked += worktimes.HoursWorked.TimeOfDay;
                }
            }
        }
        private void Calculate()
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
        private void SetDisplayValues()
        {
            DisplayTotalOvertime = TotalOvertime.TotalHours.ToString();
            DisplayTotalLate = TotalLate.TotalHours.ToString();
            DisplayTotalHoursWorked = TotalHoursWorked.TotalHours.ToString();
        }
        private void ResetValues()
        {
            TemporarySalary = 0;
            TotalOvertime = TimeSpan.Zero;
            TotalLate = TimeSpan.Zero;
            TotalEarnings = 0;
            TotalDeductions = 0;
            FinalSalary = 0;
        }
        private int selectedMonth = 0;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set { selectedMonth = value; OnPropertyChanged(); OnPropertyChanged(nameof(selectedMonth)); PickerMonth_SelectedIndexChanged(); }
        }
        private void PickerMonth_SelectedIndexChanged()
        {
            chosenMonth = new DateTime(DateTime.Now.Year, SelectedMonth+1, DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth+1));
            ResetValues();
            Total(); 
            Calculate(); 
            SetDisplayValues();
        }
    }
}
