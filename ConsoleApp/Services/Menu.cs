using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class Menu
    {
        private FileService file = new();
        public string FilePath { get; set; } = null!;

        public void WelcomeMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Adressboken!");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.WriteLine("Välj ett av alternativen ovan: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1": CreateUser(); break;
                case "2": ShowAllUsers(); break;
                case "3": ShowSpecificUser(); break;
                case "4": RemoveUser(); break;

                default:
                    Console.WriteLine("Incorrect, try again");
                    break;
            }
        }


        private void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Skapa en kontakt");

            User user = new();
            Console.Write("Skriv in förnamn: ");
            user.FirstName = Console.ReadLine() ?? "";
            Console.Write("Skriv in efternamn: ");
            user.LastName = Console.ReadLine() ?? "";
            Console.Write("Skriv in e-postadress: ");
            user.Email = Console.ReadLine() ?? "";
            Console.Write("Skriv in telefonnummer: ");
            user.PhoneNumber = Console.ReadLine() ?? "";
            Console.Write("Skriv in adress: ");
            user.Adress = Console.ReadLine() ?? "";

            file.AddToList(new User { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, PhoneNumber = user.PhoneNumber, Adress = user.Adress });
        }

        private void ShowAllUsers()
        {
            Console.Clear();
            Console.WriteLine("Visa alla kontaker");
            file.ReadFromFile();

            Console.ReadKey();
        }

        private void ShowSpecificUser()
        {
            Console.Clear();
            Console.WriteLine("Visa en specifik kontakt");
            file.ReadFromFile();
            Console.Write("Skriv förnamnet på personen du vill visa: ");
            var nameChoice = Console.ReadLine();
            file.Get(nameChoice!);
        }

        private void RemoveUser()
        {
            Console.Clear();
            Console.WriteLine("Ta bort en specifik kontakt");
            file.ReadFromFile();
            Console.Write("Skriv namnet på personen du vill ta bort: ");
            var nameChoice = Console.ReadLine();
            file.RemoveFromList(nameChoice!);
        }
    }
}
