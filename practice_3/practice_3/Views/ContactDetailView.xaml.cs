using practice_3.Models;
using practice_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practice_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailView : ContentPage
    {
        public ContactDetailView(Contact contact)
        {
            InitializeComponent();
            BindingContext = new ContactFieldsViewModel(contact);
        }
    }
}