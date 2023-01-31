using ConsoleApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FileService
    {
        private string filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\users.json";
        private List<User> users = new List<User>();
        public FileService()
        {
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd())!;

                var i = 1;
                foreach (var item in users!)
                    Console.WriteLine($"{i++}. {item.DisplayName}");

            }
            catch { users = new List<User>(); }
        }

        public void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(users));
            
        }

        public void AddToList(User user)
        {
            users.Add(user);
            SaveToFile();
        }

        public void Get(string handleChoice)
        {
            var finduser = users.Find(x => x.FirstName == handleChoice);
            if (finduser != null)
            {
                Console.Clear();
                Console.WriteLine(finduser!.ContactDetails);
                Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till menyn: ");
            }
            else
                Console.WriteLine("Ingen kontakt med det namned du angav hittades. Försök igen");

            Console.ReadKey();
        }

        public void RemoveFromList(string handleChoice)
        {
            var finduser = users.Find(x => x.FirstName == handleChoice);
            if (finduser != null)
            {
                Console.WriteLine("Är du säker att du vill ta bort kontakten? (y/n)");
                var result = Console.ReadLine();
                if (result?.ToLower() == "y")
                {
                    users.Remove(finduser!);
                    SaveToFile();
                    Console.WriteLine("Kontakt borttagen.");
                }
            }
            else
                Console.WriteLine("Ingen kontakt med det namned du angav hittades. Försök igen");
            Console.ReadKey();
        }
    }
}
