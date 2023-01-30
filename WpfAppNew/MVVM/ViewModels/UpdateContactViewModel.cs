using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfAppNew.MVVM.Models;
using WpfAppNew.Services;

namespace WpfAppNew.MVVM.ViewModels
{
    public partial class UpdateContactViewModel : ObservableObject
    {
        private readonly FileService fileService;
        private ContactModel updatedInfo;

        public UpdateContactViewModel()
        {
            fileService = new FileService();

        }


        [ObservableProperty]
        private string pageTitle = "Uppdatera kontaktuppgifter";

        [ObservableProperty]
        private Guid id;
        [ObservableProperty]
        private string firstNameText = ContactService.contact.FirstName;
        [ObservableProperty]
        private string lastNameText = ContactService.contact.LastName;
        [ObservableProperty]
        private string emailText = ContactService.contact.Email;
        [ObservableProperty]
        private string phonenumberText = ContactService.contact.PhoneNumber;
        [ObservableProperty]
        private string adressText = ContactService.contact.Adress;



        [RelayCommand]
        private void Update()
        {

            //LastNameText = updatedContactInfo.LastName;
            //EmailText = updatedContactInfo.Email;
            //PhonenumberText = updatedContactInfo.PhoneNumber;
            //AdressText = updatedContactInfo.Adress;
            updatedInfo = ContactService.contact;
            updatedInfo.FirstName = FirstNameText;
            updatedInfo.LastName= LastNameText;
            updatedInfo.Email = EmailText;
            updatedInfo.PhoneNumber = PhonenumberText;
            updatedInfo.Adress = AdressText;
            ContactService.UpdateContact(updatedInfo);


        }
    }
}
