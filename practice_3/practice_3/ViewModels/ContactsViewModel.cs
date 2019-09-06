using practice_3.Models;
using practice_3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class ContactsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        async public static Task<ContactsViewModel> ContactsViewModelAsync()
        {
            List<Contact> tmpData = await App.Database.GetPeopleAsync();
            ObservableCollection<Contact> contactsObv = new ObservableCollection<Contact>(tmpData);
            return new ContactsViewModel();
        }

        public ICommand EditContact { get; set; }

        public ICommand ContactOptions { get; set; }

        public ContactsViewModel()
        {
            // Load all the contacts from the db
            Task.Run(async () =>
            {
                List<Contact> tmpData = await App.Database.GetPeopleAsync();
                ObservableCollection<Contact> contactsObv = new ObservableCollection<Contact>(tmpData);
                Contacts = contactsObv;
            });

            EditContact = new Command<Contact>(async (Contact contact) =>
            {
                await App.Database.DeletePersonAsync(contact);
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
            MessagingCenter.Subscribe<string, Contact>("Contacts", "AddContact", (async(sender, contact) =>
            {

                await App.Database.SavePersonAsync(contact);

                this.Contacts.Add(contact);
            }));

            MessagingCenter.Subscribe<string, Contact>("Contacts", "EditContact", (async (sender, contact) =>
            {
                await App.Database.UpdatePersonAsync(contact);
                int idx = this.Contacts.IndexOf(contact);
                this.Contacts[idx] = contact;
            }));
        }
    }
}

