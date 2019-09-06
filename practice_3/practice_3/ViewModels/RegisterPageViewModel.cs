using practice_3.Models;
using practice_3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class RegisterPageViewModel : INotifyPropertyChanged
    {
        public ICommand RegisterCommand { get; set; }
        public Person Person { get; set; }

        public string Password2 { get; set; }

        public string Errors { get; set; }
        public RegisterPageViewModel()
        {
            Person = new Person();
            RegisterCommand = new Command(async () =>
            {
            if (String.IsNullOrEmpty(Person.Username) ||
                String.IsNullOrEmpty(Person.Email) ||
                String.IsNullOrEmpty(Person.Password) ||
                String.IsNullOrEmpty(Password2))
            {
                Errors = "All fields mut be filled";
            }
            else if (Person.Password != Password2)
            {
                Errors = "Passwords fields don't match";
            }
            else
            {
                 await App.Current.MainPage.Navigation.PushAsync(new LoginView());
            }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
