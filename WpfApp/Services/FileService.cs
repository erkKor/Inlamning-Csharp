using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.MVVM.Models;

namespace WpfApp.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\wpfusers.json";
        private List<UserModel> users = new List<UserModel>();

        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                users = JsonConvert.DeserializeObject<List<UserModel>>(sr.ReadToEnd())!;
                
            }
            catch { users = new List<UserModel>(); }
        }

        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(users));
        }

        public void AddToList(UserModel user)
        {
            users.Add(user);
            SaveToFile();
        }


        public void RemoveFromList(UserModel user)
        {
            var finduser = users.Find(x => x.Id == user.Id);
            users.Remove(finduser!);
            SaveToFile();
        }

        public void UpdateUserInList(UserModel user)
        {
            var finduser = users.Find(x => x.Id == user.Id);
            //users.(finduser!);
            SaveToFile();
        }

        public ObservableCollection<UserModel> Users()
        {
            var items = new ObservableCollection<UserModel>();
            foreach (var user in users)
                items.Add(user);

            return items;
        }


    }
}
