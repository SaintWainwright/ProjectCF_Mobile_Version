using System.Globalization;

namespace ProjectCF_Mobile_Version.Converter
{
    public class MessageTagTextConverter : IValueConverter
    {
        public string tagText;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tag = (int)value;
            if (tag == 0)
            {
                return tagText = "Unread";
            }
            else if (tag == 1)
            {
                return tagText = "Read";
            }
            else if (tag == 2)
            {
                return tagText = "Pending";
            }
            else if (tag == 3)
            {
                return tagText = "Approved";
            }
            else if (tag == 4)
            {
                return tagText = "Rejected";
            }
            else
            {
                return tagText = "Error";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
