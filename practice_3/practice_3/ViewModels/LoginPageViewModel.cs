using practice_3;
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
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
        public Person Person { get; set; }

        public string Errors { get; set; }
        public LoginPageViewModel()
        {
            Person = new Person();
            LoginCommand = new Command(async () =>
            {
                if (String.IsNullOrEmpty(Person.Username))
                {
                    Errors = "User field cannot be empty";
                }
                else if (String.IsNullOrEmpty(Person.Password))
                {
                    Errors = "Password field cannot be empty";
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new MainPageView());
                    await App.Current.MainPage.Navigation.PopToRootAsync(true);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
