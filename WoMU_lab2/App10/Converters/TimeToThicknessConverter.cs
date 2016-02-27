using App10.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace App10.Converters
{
    public class TimeToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var task = (TaskModel)value;
            double duration = (task.BeginDateTime - System.DateTime.Today).TotalDays;

            return new Thickness((duration * 10),0,0,0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
