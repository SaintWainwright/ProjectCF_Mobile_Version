using CommunityToolkit.Mvvm.ComponentModel;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class ViewSalary_VM : ObservableObject
    {
        public ViewSalary_VM()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            totalOvertime = TimeSpan.Zero;
            totalLate = TimeSpan.Zero;
            totalHoursWorked = TimeSpan.Zero;
            MonthPicker =
            [
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
            ];
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private TimeSpan totalOvertime;
        [ObservableProperty]
        private TimeSpan totalLate;
        [ObservableProperty]
        private TimeSpan totalHoursWorked;
        [ObservableProperty]
        private TimeSpan totalUndertime;
        [ObservableProperty]
        private String displayTotalOvertime;
        [ObservableProperty]
        private String displayTotalLate;
        [ObservableProperty]
        private String displayTotalHoursWorked;
        [ObservableProperty]
        private double overtimeBonus;
        [ObservableProperty]
        private double lateDeductions;
        [ObservableProperty]
        private double underTimes;
        [ObservableProperty]
        private double temporarySalary;
        [ObservableProperty]
        private double finalSalary;
        [ObservableProperty]
        private double totalEarnings;
        [ObservableProperty]
        private double totalDeductions;
        [ObservableProperty]
        private double taxes;
        [ObservableProperty]
        private double pagibig;
        [ObservableProperty]
        private double philHealth;
        [ObservableProperty]
        private double sss;
        [ObservableProperty]
        private DateTime chosenMonth;
        [ObservableProperty]
        private ObservableCollection<string> monthPicker;
        private void Total()
        {
            foreach (Employee_Worktimes worktimes in CurrentEmployee.Worktimes)
            {
                if(worktimes.Month.Month == ChosenMonth.Month && worktimes.Year.Year == ChosenMonth.Year)
                {
                    TotalOvertime += worktimes.Overtimes.TimeOfDay;
                    TotalLate += worktimes.Lates.TimeOfDay;
                    TotalHoursWorked += worktimes.HoursWorked.TimeOfDay;
                    TotalUndertime += worktimes.Undertimes.TimeOfDay;
                }
            }
        }
        private void Calculate()
        {
            TotalHoursWorked -= TotalOvertime;
            TemporarySalary = CurrentEmployee.SalaryGrade * TotalHoursWorked.TotalHours;
            OvertimeBonus = (CurrentEmployee.SalaryGrade + 2.0) * TotalOvertime.TotalHours;
            LateDeductions = (CurrentEmployee.SalaryGrade + 5.0) * TotalLate.TotalHours;
            UnderTimes = (CurrentEmployee.SalaryGrade + 5.0) * TotalUndertime.TotalHours;
            Taxes = TemporarySalary * 0.0116;
            Pagibig = TemporarySalary * 0.03;
            PhilHealth = TemporarySalary * 0.04;
            Sss = TemporarySalary * 0.045;
            TotalEarnings = ((TemporarySalary + OvertimeBonus) - UnderTimes) - LateDeductions;
            TotalDeductions = Taxes + Pagibig + PhilHealth + Sss;
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
            OvertimeBonus = 0;
            LateDeductions = 0;
            UnderTimes = 0;
            TotalOvertime = TimeSpan.Zero;
            TotalLate = TimeSpan.Zero;
            TotalUndertime = TimeSpan.Zero;
            Taxes = 0;
            Pagibig = 0;
            PhilHealth = 0;
            Sss = 0;
            TotalHoursWorked = TimeSpan.Zero;
            TotalEarnings = 0;
            TotalDeductions = 0;
            FinalSalary = 0;
        }
        private int selectedMonth = DateTime.Now.Month - 1;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set { selectedMonth = value; OnPropertyChanged(); OnPropertyChanged(nameof(selectedMonth)); PickerMonth_SelectedIndexChanged(); }
        }
        private void PickerMonth_SelectedIndexChanged()
        {
            ChosenMonth = new DateTime(DateTime.Now.Year, SelectedMonth + 1, DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth + 1));
            ResetValues();
            Total(); 
            Calculate(); 
            SetDisplayValues();
        }
    }
}
