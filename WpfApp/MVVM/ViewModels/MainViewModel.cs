using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void GoToAddUser()
        {
            CurrentViewModel = new AddUserViewModel();
        }

        [RelayCommand]
        private void GoToUsers()
        {
            CurrentViewModel = new UsersViewModel();
        }

        [RelayCommand]
        public void GoToUpdateUser(ObservableObject viewModel)
        {
            CurrentViewModel = new UpdateUserViewModel();
        }

        public MainViewModel()
        {
            CurrentViewModel = new UsersViewModel();
        }
    }
}
