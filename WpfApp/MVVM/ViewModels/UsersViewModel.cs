using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public UserModel selectedUser = null!;
        //private MainViewModel mainView;
        UpdateUserViewModel updatEuser;

        [ObservableProperty]
        public ObservableObject currentViewmodel;

        public UsersViewModel()
        {
            fileService = new FileService();
            users = fileService.Users();
        }



        [ObservableProperty]
        private string pageUsersTitle = "Kontakter";
        [ObservableProperty]
        private string updateTitle = "Uppdatera kontakt";

        [ObservableProperty]
        private ObservableCollection<UserModel> users;

        [ObservableProperty]
        private string userInfo = null!;
        [ObservableProperty]
        private string firstNameText = "Test";

        [RelayCommand]
        public void SelectedUser(UserModel user)
        {

            UserInfo = user.ContactDetails;
            //MessageBox.Show(UserInfo);

            selectedUser = user;
            //OnPropertyChanged("UserInfo");
            

        }

        [RelayCommand]
        private void RemoveUser(UserModel user)
        {
            MessageBoxResult msgBoxResult = MessageBox.Show("Är du säker på att du vill ta bort kontakten?", "Ta bort kontakt", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (msgBoxResult == MessageBoxResult.Yes)
            {
                fileService.RemoveFromList(selectedUser);
            }
        }

        
        [RelayCommand]
        private void UpdateUser()
        {

            //updatEuser = new UpdateUserViewModel();
            //updatEuser.SetForm(selectedUser);
            //updatEuser.selectedUser= selectedUser;
            FirstNameText = selectedUser.FirstName;
            CurrentViewmodel = new UpdateUserViewModel();


        }

        



    }
}
