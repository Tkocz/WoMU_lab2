﻿using App10.Models;
using System;
using Windows.UI.Xaml.Data;

namespace App10.Converters
{
    public class TaskToDurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var task = (TaskModel)value;
            double duration = (task.DeadlineDateTime - task.BeginDateTime).TotalDays;

            return duration*10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
