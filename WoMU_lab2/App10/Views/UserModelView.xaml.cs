﻿using System;
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
    public sealed partial class UserModelsView : Page
    {
        public UserModelsView()
        {
            this.InitializeComponent();
        }

        private void GoToAddNewTaskPage_OnClick(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(typeof(NewTaskModelView));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
