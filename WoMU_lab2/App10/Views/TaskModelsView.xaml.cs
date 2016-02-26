using App10.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App10.Views
{
    public sealed partial class TaskModelsView : Page
    {
        public TaskModelsView()
        {
            this.InitializeComponent();
        }

        private void GoToDetailsPage_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailsModelView));
        }
        public int TimeSpanCalculator(TaskModel task)
        {
            int startTimeInt;
            int endTimeInt;
            int.TryParse((task.BeginDateTime.ToString("yyyymmddhh")), out startTimeInt);
            int.TryParse((task.DeadlineDateTime.ToString("yyyymmddhh")), out endTimeInt);

            return endTimeInt - startTimeInt;
        }
    }
}
