using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppNew.MVVM.Models;
using WpfAppNew.Services;

namespace WpfAppNew.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        MainViewModel mainView;

        [ObservableProperty]
        private string title = "contatcs";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [ObservableProperty]
        public ObservableObject currentViewmodel;



        [RelayCommand]
        public void Remove()
        {

            MessageBoxResult msgBoxResult = MessageBox.Show($"Är du säker på att du vill ta bort {SelectedContact.DisplayName}?", "Ta bort kontakt", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (msgBoxResult == MessageBoxResult.Yes)
            {
                ContactService.RemoveContact(SelectedContact);
            }
            
        }



        [ObservableProperty]
        private string firstNameText = "Test";

        [RelayCommand]
        public void UpdateContact()
        {
            ContactService.contact = SelectedContact;
            //CurrentViewmodel = new UpdateContactViewModel();    
        }
    }

}
