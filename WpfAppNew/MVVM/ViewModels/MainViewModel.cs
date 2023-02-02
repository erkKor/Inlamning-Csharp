using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppNew.Services;

namespace WpfAppNew.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public static ObservableObject currentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void GoToAddContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void GoToContacts() 
        { 
            CurrentViewModel = new ContactsViewModel();
            ContactService.contact = null!;
        }

        [RelayCommand]
        private void GoToUpdateContact() 
        { 
            if(ContactService.contact != null)
            {
                CurrentViewModel = new UpdateContactViewModel();
            }
            else
            {
                MessageBox.Show($"Du måste välja en kontakt att uppdatera först.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
    }
}
