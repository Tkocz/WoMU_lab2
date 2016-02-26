using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App10.ViewModels;
using App10.Models;

namespace App10.Views
{
    
    public sealed partial class DetailsModelView : Page
    {
        private TaskModel currentTask;

        public DetailsModelView()
        {
            this.InitializeComponent();

            String userList = "";
            App thisApp = Application.Current as App;
            currentTask = thisApp.currentTask;

            titleBlock.Text         += currentTask.Title;
            requirementsBlock.Text   = currentTask.Requirements;
            startBlock.Text         += currentTask.BeginDateTime.ToString("yy-MM-dd");
            deadlineBlock.Text      += currentTask.DeadlineDateTime.ToString("yy-MM-dd");

            foreach(UserModel user in currentTask.Users){
                userList += user.FirstName + " " + user.LastName + ", ";
            }
            userBlock.Text += userList;
        }
        private void GoToPreviousPage_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
