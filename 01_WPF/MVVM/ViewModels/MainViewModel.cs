using _01_WPF.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using _01_WPF.Services;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

namespace _01_WPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void GoToAddContacts() => CurrentViewModel = new AddContactsViewModel();

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactsViewModel();

        public MainViewModel()
        {
            CurrentViewModel = new ContactsViewModel();
        }

    }
}

