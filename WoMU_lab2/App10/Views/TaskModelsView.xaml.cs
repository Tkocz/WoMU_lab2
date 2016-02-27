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
using App10.Models;
using Windows.UI;

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
            try {
                if (sender == null) return;
                App thisApp = Application.Current as App;
                thisApp.currentTask = (TaskModel)listView.SelectedItems[0];
                this.Frame.Navigate(typeof(DetailsModelView));
            }
            catch {
                return;
            }

        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e) {

            if (sender == null) return;

            App thisApp = Application.Current as App;
            var temp = (TextBlock)sender;
            var task = (TaskModel)temp.DataContext;
            temp.Text = "";
            Boolean currentUserAttached = false;
            

            //Om tasken har en user och det är nuvarande user.
            if((int)task.Users.Count() == 1 && thisApp.currentUser.Id == task.Users.ElementAt(0).Id) {
                temp.Text = "●";
                temp.Foreground = new SolidColorBrush(Colors.LimeGreen);
                return;
            }

            //Om det finns fler users.
            for (int i = 0; i < (int)task.Users.Count(); i++) {
                if (task.Users.ElementAt(i).Id == thisApp.currentUser.Id)
                    currentUserAttached = true;
                temp.Text += "●";
            }

            //Om tasken har flera user och en av dom är nuvarande user.
            if(currentUserAttached)
                temp.Foreground = new SolidColorBrush(Colors.Orange);
            //Om tasken är tagen av en annan eller flera users.
            else
                temp.Foreground = new SolidColorBrush(Colors.Red);
            
        }
    }
}
