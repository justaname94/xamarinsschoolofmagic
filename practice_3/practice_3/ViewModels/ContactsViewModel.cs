using practice_3.Models;
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

            MessagingCenter.Subscribe<string, Contact>("Contacts", "AddContact", ((sender, contact) =>
            {
                this.Contacts.Add(contact);
            }));
        }
    }
}

