using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Worktime_VM : LandingPage_VM
    {
        public Worktime_VM()
        {
            employee_Services = new Employee_Services();
            InitializeCurrentEmployee();
            DateToday = DateOnly.FromDateTime(DateTime.Today);
            TimeNow = TimeOnly.FromDateTime(DateTime.Now);
            DateSimulation = DateToday.ToDateTime(TimeOnly.MinValue);
            TimeInSimulated = DateTime.Now;
            TimeOutSimulated = DateTime.Now;
            timeCompare = TimeOnly.MinValue;
            optimalTimeIn = DateTime.Today.AddHours(7);
            optimalTimeOut = DateTime.Today.AddHours(21);
        }
        private readonly DateTime optimalTimeIn;
        private readonly DateTime optimalTimeOut;
        private readonly TimeOnly timeCompare;
        private DateTime dateException;
        private readonly Employee_Services employee_Services;

        private DateOnly dateToday;
        public DateOnly DateToday
        {
            get { return dateToday; }
            set { dateToday = value; OnPropertyChanged(); OnPropertyChanged(nameof(dateToday)); }
        }
        private TimeOnly timeNow;
        public TimeOnly TimeNow
        {
            get { return timeNow; }
            set { timeNow = value; OnPropertyChanged(); OnPropertyChanged(nameof(timeNow)); }
        }
        private DateTime _DateSimulation;
        public DateTime DateSimulation
        {
            get { return _DateSimulation; }
            set { _DateSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_DateSimulation)); }
        }
        private TimeSpan _TimeInSimulation;
        public TimeSpan TimeInSimulation
        {
            get { return _TimeInSimulation; }
            set { _TimeInSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeInSimulation)); }
        }
        private TimeSpan _TimeOutSimulation;
        public TimeSpan TimeOutSimulation
        {
            get { return _TimeOutSimulation; }
            set { _TimeOutSimulation = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOutSimulation)); }
        }
        private DateTime _TimeIn;
        public DateTime TimeInSimulated
        {
            get { return _TimeIn; }
            set { _TimeIn = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeIn)); }
        }
        private DateTime _TimeOut;
        public DateTime TimeOutSimulated
        {
            get { return _TimeOut; }
            set { _TimeOut = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOut)); }
        }
        private Employee_Worktimes SimulationWorkTimes = new();

        private void Simulate()
        {
            SetDates();
            TimeSpan theduration;
            if (TimeOutSimulated.Hour == timeCompare.Hour)
            {
                dateException = TimeOutSimulated;
                dateException = dateException.AddDays(1);
                theduration = dateException - TimeInSimulated;
            }
            else
            {
                theduration = TimeOutSimulated - TimeInSimulated;
            }
            SimulationWorkTimes.HoursWorked = SimulationWorkTimes.HoursWorked.Add(theduration);
            if (optimalTimeIn < TimeInSimulated)
            {
                theduration = TimeInSimulated - optimalTimeIn;
                SimulationWorkTimes.Lates = SimulationWorkTimes.Lates.Add(theduration);
            }
            if (optimalTimeOut < TimeOutSimulated && TimeOutSimulated.Hour != timeCompare.Hour)
            {
                theduration = TimeOutSimulated - optimalTimeOut;
                SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
            }
            else if (TimeOutSimulated.Hour == timeCompare.Hour)
            {
                dateException = TimeOutSimulated;
                dateException = dateException.AddDays(1);
                theduration = dateException - optimalTimeOut;
                SimulationWorkTimes.Overtimes = SimulationWorkTimes.Overtimes.Add(theduration);
            }
            SimulationWorkTimes.Month = TimeInSimulated;
            SimulationWorkTimes.Year = TimeInSimulated;
            SimulationWorkTimes.HoursWorked = SimulationWorkTimes.HoursWorked.Add(theduration);
            SimulationWorkTimes.TimeIn = TimeInSimulated;
            SimulationWorkTimes.TimeOut = TimeOutSimulated;
            CurrentEmployee.Worktimes.Add(SimulationWorkTimes);
            Shell.Current.DisplayAlert("Simulate Worktime", "Worktime Simulation Successful", "Okay");
            employee_Services.UpdateEmployeeCollection(CurrentEmployee);
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
    }
}
