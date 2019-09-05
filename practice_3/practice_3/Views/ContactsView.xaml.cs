using practice_3.Models;
using practice_3.ViewModels;
using practice_3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace practice_3
{
    [DesignTimeVisible(false)]
    public partial class ContactsView : ContentPage
    {
        public ContactsView()
        {
            InitializeComponent();
            BindingContext = new ContactsViewModel();
        }

        async private void SendToAddContactView(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditContactView());
        }

        async private void ContactsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ContactDetailView((Contact)e.Item));
        }
    }
}
