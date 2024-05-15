using System.Globalization;

namespace ProjectCF_Mobile_Version.Converter
{
    public class WorktimeTimeInColorConverter: IValueConverter
    {
        public Color color { get; set; } = Colors.Green;
        private DateTime optimalTimeIn = DateTime.Today.AddHours(7);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime test = (DateTime)value;
            if (test.Hour > optimalTimeIn.Hour)
            {
                return color = Colors.Red;
            }    
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
