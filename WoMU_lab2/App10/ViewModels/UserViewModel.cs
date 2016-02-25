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
    public class UsersViewModel : INotifyPropertyChanged
    {

        private List<UserModel> _allUserModels;
        private UserModel _oneUserModel = new UserModel();

        public List<UserModel> AllUserModels
        {
            get
            {
                return _allUserModels;
            }
            set
            {
                _allUserModels = value;
                OnPropertyChanged();
            }
        }

        public UserModel OneUserModel
        {
            get
            {
                return _oneUserModel;
            }
            set
            {
                _oneUserModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetUserModelCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await DownloadUserModelsAsync();
                });
            }
        }

        public UsersViewModel()
        {

            DownloadUserModelsAsync();
        }

        private async Task DownloadUserModelsAsync()
        {
            var userModelServices = new UserModelServices();

            AllUserModels = await userModelServices.GetUserModelsAsync();
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