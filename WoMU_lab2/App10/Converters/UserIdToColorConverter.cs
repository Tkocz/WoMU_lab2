using App10.Models;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace App10.Converters
{
    public class UserIdToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var id = (int)value;

            switch (id) {
                case 1: return "#FAAC58";
                case 2: return "#F5A9F2";
                case 3: return "#B40486";
                default:return "#000000";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
