using App10.Models;
using System;
using Windows.UI.Xaml.Data;

namespace App10.Converters
{
    public class TaskToDurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var task = (TaskModel)value;
            int startTimeInt;
            int endTimeInt;
            int.TryParse((task.BeginDateTime.ToString("yyyymmdd")), out startTimeInt);
            int.TryParse((task.DeadlineDateTime.ToString("yyyymmdd")), out endTimeInt);

            return endTimeInt+1 - startTimeInt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
