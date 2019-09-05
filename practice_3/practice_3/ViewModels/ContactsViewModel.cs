using practice_3.Models;
using practice_3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class ContactsViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public ICommand EditContact { get; set; }

        public ICommand ContactOptions { get; set; }

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact> {
                new Contact("Roniel Valdez", "8296296344"),
                new Contact("Albin Frias", "8297431205"),
                new Contact("Gilbert Batista", "8293448895")
            };


            EditContact = new Command<Contact>(async (Contact contact) =>
            {
                this.Contacts.Remove(contact);
            });

            ContactOptions = new Command<Contact>(async (contact) =>
            {
                string action = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, "Call " + contact.Number, "Edit");
                if (action == "Edit")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new EditContactView(contact));
                }
                else
                {
                    Device.OpenUri(new Uri(String.Format("tel:{0}", contact.Number)));
                }
            });

            // Subscriptions
            MessagingCenter.Subscribe<string, Contact>("Contacts", "AddContact", ((sender, contact) =>
            {
                this.Contacts.Add(contact);
            }));

            MessagingCenter.Subscribe<string, Contact>("Contacts", "EditContact", ((sender, contact) =>
            {
                int idx = this.Contacts.IndexOf(contact);
                this.Contacts[idx] = contact;
            }));
        }

       
    }
}

