using SimpleLogin.ViewModels;
using SimpleLogin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleLogin
{
    [DesignTimeVisible(false)]
    public partial class PersonLoginView : ContentPage
    {
        public PersonLoginView()
        {
            InitializeComponent();
            BindingContext = new PersonLoginViewModel();
            
        }

        async private void SendToRegisterView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonRegisterView());   
        }

            }
}
