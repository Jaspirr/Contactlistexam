using _01_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WPF.Services
{
    internal class FileService
    {
       
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

        public ObservableCollection<Contact> ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                return JsonConvert.DeserializeObject<ObservableCollection<Contact>>(sr.ReadToEnd())!;
            }
            catch { return new ObservableCollection<Contact>(); }
        }

        public void SaveToFile(ObservableCollection<Contact> contacts)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

        public void Remove(Contact contact)
        {
            contacts.Remove(contact);
            SaveToFile(contacts);
        }

        public void Edit(Contact selectedContact)
        {
            var contacts = ReadFromFile();
            Contact foundContact = contacts.FirstOrDefault(x => x.Id == selectedContact.Id);

            if (foundContact != null)
                contacts.Remove(foundContact);

            contacts.Add(selectedContact);
            SaveToFile(contacts);
        }

        internal void SaveToFile(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}


