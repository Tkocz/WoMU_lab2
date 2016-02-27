using App10.Models;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace App10.Converters
{
    public class IdToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var task = (TaskModel)value;
            int caseInt;
            Int32.TryParse(task.Id, out caseInt);
            caseInt = caseInt % 3;
            switch (caseInt) {
                case 0: return "#E5E5FF";
                case 1: return "#F5A9F2";
                case 2: return "#B40486";
                default:return "#000000";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
