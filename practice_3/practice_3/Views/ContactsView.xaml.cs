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
            BindingContext = new ContactsViewModel();
            InitializeComponent();
        }

        async private void SendToAddContactView(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditContactView());
        }
    }
}
