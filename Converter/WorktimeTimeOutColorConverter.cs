﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Converter
{
    public class WorktimeTimeOutColorConverter : IValueConverter
    {
        public Color color { get; set; } = Colors.Green;
        private DateTime optimalTimeOut = DateTime.Today.AddHours(21);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime test = (DateTime)value;
            if (test.Hour < optimalTimeOut.Hour)
            {
                return color = Colors.Red;
            }
            else if(test.Hour > optimalTimeOut.Hour)
            {
                return color = Colors.Green;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}