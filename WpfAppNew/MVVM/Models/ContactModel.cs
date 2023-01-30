using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNew.MVVM.Models
{
    public interface IContact
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }
    }
    public class ContactModel : IContact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string DisplayName => $"{FirstName} {LastName}";
        public string ContactDetails => $"Förnamn: {FirstName} \nEfternamn: {LastName}\nE-postadress: {Email}\nTelefonnummer: {PhoneNumber}\nAdress: {Adress}";
    }
}
