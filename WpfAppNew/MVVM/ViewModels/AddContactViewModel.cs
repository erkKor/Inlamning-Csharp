using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppNew.MVVM.Models;
using WpfAppNew.Services;

namespace WpfAppNew.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Lägg till kontakt";

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
            ContactService.AddContact(new ContactModel { FirstName = FirstNameText, LastName = LastNameText, Email = EmailText, PhoneNumber = PhonenumberText, Adress = AdressText });
            FirstNameText = string.Empty;
            LastNameText = string.Empty;
            EmailText = string.Empty;
            PhonenumberText = string.Empty;
            AdressText = string.Empty;
        }
    }
}
