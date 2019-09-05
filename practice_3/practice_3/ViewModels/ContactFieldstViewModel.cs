using practice_3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class ContactFieldsViewModel
    {
        public ICommand EditContactCommand { get; set; }

        public Contact contact { get; set; }
            
        public ContactFieldsViewModel()
        {
            contact = new Contact();

            EditContactCommand = new Command(async () =>
            {
                MessagingCenter.Send<string, Contact>("Contacts", "AddContact", contact);

                await App.Current.MainPage.Navigation.PopAsync();
            });

        }

        public ContactFieldsViewModel(Contact current_contact)
        {
            contact = current_contact;

            EditContactCommand = new Command(async () =>
            {
                MessagingCenter.Send<string, Contact>("Contacts", "EditContact", contact);

                await App.Current.MainPage.Navigation.PopAsync();
            });

        }
    }
}
