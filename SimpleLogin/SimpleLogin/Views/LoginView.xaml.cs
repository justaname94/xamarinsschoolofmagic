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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
            
        }

        async private void SendToRegisterView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterView());   
        }

            }
}
