using FluentAssertions;
using System.Collections.ObjectModel;
using WpfAppNew.MVVM.Models;
using WpfAppNew.MVVM.ViewModels;

namespace WpfAppNew.Tests
{
    public class ContactsViewModel_Tests
    {
        private ContactsViewModel viewModel;

        public ContactsViewModel_Tests()
        {
            viewModel= new ContactsViewModel();
        }

        [Fact]
        public void Add_Contact_To_List()
        {
            ContactModel contact = new ContactModel { FirstName = "Erik", LastName = "Körberg" };

            viewModel.Contacts.Add(contact);

            viewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();
            viewModel.Contacts.Should().Contain(contact);
        }
    }
}