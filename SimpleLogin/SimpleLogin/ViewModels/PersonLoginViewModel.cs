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
    class PersonLoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
        public Person person { get; set; }

        public String Errors { get; set; }
        public PersonLoginViewModel()
        {
            person = new Person();
            LoginCommand = new Command(async () =>
            {
                if (String.IsNullOrEmpty(person.Username))
                {
                    Errors = "User field cannot be empty";
                }
                else if (String.IsNullOrEmpty(person.Password))
                {
                    Errors = "Password field cannot be empty";
                }
                else
                {

                    App.Current.MainPage = new NavigationPage(new MainTabPageView());
                    await App.Current.MainPage.Navigation.PopToRootAsync(true);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
