using App10.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace App10.Converters
{
    public class TimeToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var task = (TaskModel)value;
            int timeInt;
            int schemaStartDate;
            timeInt = Int32.Parse((task.BeginDateTime.ToString("yyyyMMdd")));
            schemaStartDate = Int32.Parse((System.DateTime.Today.ToString("yyyyMMdd")));
            schemaStartDate -= 00000100; //One month ago

            System.Diagnostics.Debug.WriteLine(timeInt - schemaStartDate);
            return new Thickness(((double)timeInt - (double)schemaStartDate),0,0,0);

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
