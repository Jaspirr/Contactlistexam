using _01_WPF.Models;
using _01_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _01_WPF.MVVM.ViewModels
{
    public partial class AddContactsViewModel : ObservableObject
    {
        private readonly FileService fileService;
        public AddContactsViewModel()
        {
            fileService = new FileService();
        }

        [ObservableProperty]
        private string pageTitle = "Add Contact";

        [ObservableProperty]
        private string firstname = string.Empty;

        [ObservableProperty]
        private string lastname = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phonenumber = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        [ObservableProperty]
        private string streetname = string.Empty;

        [ObservableProperty]
        private string postalcode = string.Empty;

        [ObservableProperty]
        private string contacts = string.Empty;

        [RelayCommand]
        private void AddContacts()
        {
            fileService.SaveToFile(new Contact { FirstName = Firstname, LastName = lastname, Email = email, PhoneNumber = phonenumber, City = City, StreetName = Streetname, PostalCode = postalcode });
            contacts = string.Empty;
        }
    }
}

