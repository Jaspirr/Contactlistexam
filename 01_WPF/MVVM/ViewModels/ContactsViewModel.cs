using _01_WPF.Models;
using _01_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WPF.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public ContactsViewModel()
        {
            fileService = new FileService();
            contacts = fileService.ReadFromFile();
        }

        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<Contact> contacts;

        [ObservableProperty]
        private Contact selectedContact = null!;
    }
}
