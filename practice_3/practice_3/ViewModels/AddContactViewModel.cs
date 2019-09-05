using practice_3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class AddContactViewModel
    {
        public ICommand AddContactCommand { get; set; }

        public Contact contact { get; set; }
            
        public AddContactViewModel()
        {
            contact = new Contact();

            AddContactCommand = new Command(async () =>
            {
                MessagingCenter.Send<string, Contact>("Contacts", "AddContact", contact);

                await App.Current.MainPage.Navigation.PopAsync();
            });

        }
    }
}
