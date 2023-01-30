using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp.MVVM.Models;
using WpfApp.Services;

namespace WpfApp.MVVM.ViewModels
{
    public partial class AddUserViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public AddUserViewModel()
        {
            fileService = new FileService();
        }

        [ObservableProperty]
        private string pageTitle = "Skapa användare";

        [ObservableProperty]
        private string firstNameText = string.Empty;

        [ObservableProperty]
        private string lastNameText = string.Empty;
        [ObservableProperty]
        private string emailText = string.Empty;
        [ObservableProperty]
        private string phonenumberText = string.Empty;
        [ObservableProperty]
        private string adressText = string.Empty;

        [RelayCommand]
        private void Add()
        {
            fileService.AddToList(new UserModel { FirstName = FirstNameText, LastName = LastNameText, Email = EmailText, PhoneNumber = PhonenumberText, Adress = AdressText });
            FirstNameText = string.Empty;
            LastNameText = string.Empty;
            EmailText = string.Empty;
            PhonenumberText = string.Empty;
            AdressText = string.Empty;
        }
    }
}
