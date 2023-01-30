using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{
    public partial class UpdateUserViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public UserModel selectedUser = null!;
        //private UsersViewModel usersView;
        public UpdateUserViewModel()
        {
            fileService = new FileService();
            //usersView = new UsersViewModel();

            //SetForm();
            //SelectedUser = usersView.selectedUser;
            
            //FirstNameText= string.Empty;
        }


        //[ObservableProperty]
        //private string firstNameText = string.Empty;
        [ObservableProperty]
        private string lastNameText = string.Empty;
        [ObservableProperty]
        private string emailText = string.Empty;
        [ObservableProperty]
        private string phonenumberText = string.Empty;
        [ObservableProperty]
        private string adressText = string.Empty;

        [RelayCommand]
        public void SelectedUser(UserModel user)
        {
            selectedUser = user;
        }

        [RelayCommand]
        public void SetForm(UserModel user)
        {
            selectedUser = user;
            //FirstNameText = user.FirstName;
        }
    }
}
