using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using App10.Models;
using App10.Services;
using App10.Tools;

namespace App10.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {

        private List<TaskModel> _allTaskModels;
        private TaskModel _oneTaskModel = new TaskModel();
        private UserModel _oneUserModel = new UserModel();

        public List<TaskModel> AllTaskModels
        {
            get
            {
                return _allTaskModels;
            }
            set
            {
                _allTaskModels = value;
                OnPropertyChanged();
            }
        }

        public TaskModel OneTaskModel
        {
            get
            {
                return _oneTaskModel;
            }
            set
            {
                _oneTaskModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetTaskModelCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await DownloadTaskModelsAsync();
                });
            }
        }

        public ICommand ClaimTaskModelCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await ClaimTaskModelAsync();
                });
            }
        }

        public ICommand ReleaseTaskModelCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await ReleaseTaskModelAsync();
                });
            }
        }
        public TasksViewModel()
        {

            DownloadTaskModelsAsync();
        }

        private async Task DownloadTaskModelsAsync()
        {
            var taskModelServices = new TaskModelServices();

            AllTaskModels = await taskModelServices.GetTaskModelsAsync();
        }

        private async Task ClaimTaskModelAsync()
        {
            var taskModelServices = new TaskModelServices();

            await taskModelServices.ClaimTaskModelAsync(_oneTaskModel, _oneUserModel);
        }
        private async Task ReleaseTaskModelAsync()
        {
            var taskModelServices = new TaskModelServices();

            await taskModelServices.ReleaseTaskModelAsync(_oneTaskModel, _oneUserModel);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
