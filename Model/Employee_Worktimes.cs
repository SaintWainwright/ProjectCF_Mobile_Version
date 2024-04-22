﻿using ProjectCF_Mobile_Version.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Model
{
    public class Employee_Worktimes : MainViewModel
    {
        private DateTime _TimeIn;
        private DateTime _TimeOut;
        private DateTime overtimes;
        private DateTime undertimes;
        private DateTime lates;
        private DateTime hoursWorked;
        private DateTime month;
        private DateTime year;
        public DateTime TimeIn
        {
            get { return _TimeIn; }
            set { _TimeIn = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeIn)); }
        }
        public DateTime TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; OnPropertyChanged(); OnPropertyChanged(nameof(_TimeOut)); }
        }
        public DateTime Overtimes
        {
            get { return overtimes; }
            set { overtimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(overtimes)); }
        }
        public DateTime Undertimes
        {
            get { return undertimes; }
            set { undertimes = value; OnPropertyChanged(); OnPropertyChanged(nameof(undertimes)); }
        }
        public DateTime Lates
        {
            get { return lates; }
            set { lates = value; OnPropertyChanged(); OnPropertyChanged(nameof(lates)); }
        }
        public DateTime HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(hoursWorked)); }
        }
        public DateTime Month
        {
            get { return month; }
            set { month = value; OnPropertyChanged(); OnPropertyChanged(nameof(month)); }
        }
        public DateTime Year
        {
            get { return year;}
            set { year = value; OnPropertyChanged(); OnPropertyChanged(nameof(year)); }
        }
    }
}
