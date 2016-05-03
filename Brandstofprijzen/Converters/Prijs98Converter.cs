using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Brandstofprijzen.Converters
{
    public class Prijs98Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                string Prijs = string.Format("Super 98: €{0}", value);
                return Prijs;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return value;
            }
            return string.Empty;
        }
    }
}
