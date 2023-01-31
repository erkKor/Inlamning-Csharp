using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    public interface IUser
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }
    }

    public class User : IUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string DisplayName => $"{FirstName} {LastName} - Email: {Email}";
        public string ContactDetails => $"Förnamn: {FirstName} \nEfternamn: {LastName}\nE-postadress: {Email}\nTelefonnummer: {PhoneNumber}\nAdress: {Adress}";
    }
}
