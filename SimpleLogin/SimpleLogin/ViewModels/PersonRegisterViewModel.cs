using SimpleLogin.Models;
using SimpleLogin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleLogin.ViewModels
{
    class PersonRegisterViewModel : INotifyPropertyChanged
    {
        public ICommand RegisterCommand { get; set; }
        public Person person { get; set; }

        public String Password2 { get; set; }

        public String Errors { get; set; }
        public PersonRegisterViewModel()
        {
            person = new Person();
            RegisterCommand = new Command(async () =>
            {
            if (String.IsNullOrEmpty(person.Username) ||
                String.IsNullOrEmpty(person.Email) ||
                String.IsNullOrEmpty(person.Password) ||
                String.IsNullOrEmpty(Password2))
            {
                Errors = "All fields mut be filled";
            }
            else if (person.Password != Password2)
            {
                Errors = "Passwords fields don't match";
            }
            else
            {
                 await App.Current.MainPage.Navigation.PushAsync(new PersonLoginView());
            }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
