using CommunityToolkit.Mvvm.ComponentModel;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Worktime_VM : ObservableObject
    {
        private readonly DateTime optimalTimeIn;
        private readonly DateTime optimalTimeOut;
        private readonly TimeOnly timeCompare;
        private DateTime dateException;
        public Worktime_VM()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            DateToday = DateOnly.FromDateTime(DateTime.Today);
            TimeNow = TimeOnly.FromDateTime(DateTime.Now);
            DateSimulation = DateToday.ToDateTime(TimeOnly.MinValue);
            TimeInSimulated = DateTime.Now;
            TimeOutSimulated = DateTime.Now;
            timeCompare = TimeOnly.MinValue;
            optimalTimeIn = DateTime.Today.AddHours(7);
            optimalTimeOut = DateTime.Today.AddHours(21);
        }
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private DateOnly dateToday;
        [ObservableProperty]
        private TimeOnly timeNow;
        [ObservableProperty]
        private DateTime dateSimulation;
        [ObservableProperty]
        private TimeSpan timeInSimulation;
        [ObservableProperty]
        private TimeSpan timeOutSimulation;
        [ObservableProperty]
        private DateTime timeInSimulated;
        [ObservableProperty]
        private DateTime timeOutSimulated;
        [ObservableProperty]
        private Employee_Worktimes simulationWorkTimes = new();

        private async void Simulate()
        {
            SetDates();
            TimeSpan second = new(0, 0, 1, 0);
            TimeSpan theduration = new TimeSpan();
            if (TimeOutSimulated.Hour == timeCompare.Hour)
            {
                bool answer = await Shell.Current.DisplayAlert("Employee Forgot to Time Out", "Is this an overtime?", "Yes", "No");
                if (answer == false)
                {
                    dateException = TimeOutSimulated;
                    dateException = dateException.AddHours(12);
                    theduration = dateException.TimeOfDay - TimeInSimulated.TimeOfDay;
                    await Shell.Current.DisplayAlert("Employee forgot to Time-Out", "Time-Out automatically set to 12:00 PM", "Okay");
                }
                else
                {
                    dateException = TimeOutSimulated;
                    dateException = dateException.AddDays(1).AddSeconds(-1);
                    theduration = dateException.TimeOfDay - optimalTimeOut.TimeOfDay;
                    theduration = theduration.Add(second);
                    SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
                    dateException = TimeOutSimulated;
                    dateException = dateException.AddDays(1);
                    theduration = dateException - TimeInSimulated;
                }
            }
            else
            {
                theduration = TimeOutSimulated.TimeOfDay - TimeInSimulated.TimeOfDay;
            }
            SimulationWorkTimes.HoursWorked = SimulationWorkTimes.HoursWorked.Add(theduration);
            CurrentEmployee.HoursWorked = CurrentEmployee.HoursWorked.Add(theduration);
            if (optimalTimeIn.TimeOfDay < TimeInSimulated.TimeOfDay)
            {
                theduration = TimeInSimulated.TimeOfDay - optimalTimeIn.TimeOfDay;
                SimulationWorkTimes.Lates = SimulationWorkTimes.Lates.Add(theduration);
            }
            if (optimalTimeOut.TimeOfDay < TimeOutSimulated.TimeOfDay && TimeOutSimulated.Hour != timeCompare.Hour)
            {
                theduration = TimeOutSimulated.TimeOfDay - optimalTimeOut.TimeOfDay;
                SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
            }
            else if (optimalTimeOut.TimeOfDay < dateException.TimeOfDay && TimeOutSimulated.Hour == timeCompare.Hour)
            {
                theduration = optimalTimeOut.TimeOfDay - dateException.TimeOfDay;
                SimulationWorkTimes.Undertimes = SimulationWorkTimes.Undertimes.Add(theduration);
            }
            else if (optimalTimeOut.TimeOfDay > dateException.TimeOfDay && TimeOutSimulated.Hour == timeCompare.Hour)
            {
                theduration = optimalTimeOut.TimeOfDay - dateException.TimeOfDay;
                SimulationWorkTimes.Undertimes = SimulationWorkTimes.Undertimes.Add(theduration);
            }
            else if (optimalTimeOut.TimeOfDay > TimeOutSimulated.TimeOfDay && TimeOutSimulated.Hour != timeCompare.Hour)
            {
                theduration = optimalTimeOut.TimeOfDay - TimeOutSimulated.TimeOfDay;
                SimulationWorkTimes.Undertimes = SimulationWorkTimes.Undertimes.Add(theduration);
            }
            SimulationWorkTimes.Month = TimeInSimulated;
            SimulationWorkTimes.Year = TimeInSimulated;
            SimulationWorkTimes.TimeIn = TimeInSimulated;
            SimulationWorkTimes.TimeOut = TimeOutSimulated;
            CurrentEmployee.Worktimes.Add(SimulationWorkTimes);
            await Shell.Current.DisplayAlert("Simulate Worktime", "Worktime Simulation Successful", "Okay");
            Employee_Services.UpdateEmployeeCollection(CurrentEmployee);
            SimulationWorkTimes = new Employee_Worktimes();
        }
        public ICommand SimulateCommand => new Command(Simulate);
        private void SetDates()
        {
            TimeInSimulated = DateSimulation;
            TimeInSimulated += TimeInSimulation;
            TimeOutSimulated = DateSimulation;
            TimeOutSimulated += TimeOutSimulation;
        }
        public void OnAppearing()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
    }
}