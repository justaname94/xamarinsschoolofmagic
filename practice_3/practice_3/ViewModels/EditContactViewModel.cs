﻿using practice_3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3.ViewModels
{
    class EditContactViewModel
    {
        public ICommand EditContactCommand { get; set; }

        public Contact contact { get; set; }
            
        public EditContactViewModel()
        {
            contact = new Contact();

            EditContactCommand = new Command(async () =>
            {
                MessagingCenter.Send<string, Contact>("Contacts", "AddContact", contact);

                await App.Current.MainPage.Navigation.PopAsync();
            });

        }

        public EditContactViewModel(Contact current_contact)
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
