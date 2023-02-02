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
        [ObservableProperty]
        private string title = "Kontaktlista";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [RelayCommand]
        public void Remove()
        {

            MessageBoxResult msgBoxResult = MessageBox.Show($"Är du säker på att du vill ta bort {SelectedContact.DisplayName}?", "Ta bort kontakt", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (msgBoxResult == MessageBoxResult.Yes)
            {
                ContactService.RemoveContact(SelectedContact);
            }
            
        }

        [RelayCommand]
        public void UpdateContact()
        {
            try
            {
                ContactService.contact = SelectedContact;
            }
            catch { }
        }
    }

}
