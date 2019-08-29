using SimpleLogin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleLogin.ViewModels
{
    class PersonViewModel
    {
        public ICommand LoginCommand { get; set; }
        public Person person { get; set; }
        public PersonViewModel()
        {
            person = new Person();
            LoginCommand = new Command(async () =>
            {
                if (String.IsNullOrEmpty(person.Username))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "User field cannot be empty", "Ok");
                }
                else if (String.IsNullOrEmpty(person.Password))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Password field cannot be empty", "Ok");
                }
                else
                {
                    string welcomeMsg = String.Format("Hello {0}", person.Username);
                    await App.Current.MainPage.DisplayAlert("Welcome", welcomeMsg, "Ok");
                }
            });
        }
    }
}
