using System.Globalization;

namespace ProjectCF_Mobile_Version.Converter
{
    public class MessageTagTextColorConverter : IValueConverter
    {
        public Color color { get; set; } = Colors.Black;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tag = (int)value;
            if(tag == 0)
            {
                return color = Colors.Gray;
            }
            else if (tag == 1)
            {
                return color = Colors.Black;
            }
            else if(tag == 2)
            {
                return color = Colors.Yellow;
            }
            else if (tag == 3)
            {
                return color = Colors.Green;
            }
            else if(tag == 4)
            {
                return color = Colors.Red;
            }
            else
            {
                return color = Colors.Blue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
