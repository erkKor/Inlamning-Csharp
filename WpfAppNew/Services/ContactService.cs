using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using WpfAppNew.MVVM.Models;

namespace WpfAppNew.Services
{
    public static class ContactService
    {
        //private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\wpfcontacts.json");
        private static ObservableCollection<ContactModel> contacts;
        public static ContactModel contact;
        private static FileService fileService = new FileService();

        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.ReadFromFile())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }

        public static void AddContact(ContactModel model)
        {
            contacts.Add(model);
            fileService.SaveToFile(JsonConvert.SerializeObject(contacts));
        }

        public static void RemoveContact(ContactModel model)
        {
            contacts.Remove(model);
            fileService.SaveToFile(JsonConvert.SerializeObject(contacts));
        }

        public static void UpdateContact(ContactModel model)
        {
            contacts.FirstOrDefault(x=> x.Id == model.Id);
            fileService.SaveToFile(JsonConvert.SerializeObject(contacts));
        }
        
        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }

  
    }
}
