using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLogin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Login(object ob, EventArgs ar)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            
            if (String.IsNullOrEmpty(username))
            {
                await DisplayAlert("Error", "User field cannot be empty", "Ok");
            } else if (String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Password field cannot be empty", "Ok");
            } else
            {
                string welcomeMsg = String.Format("Hello {0}", username);
                await DisplayAlert("Welcome", welcomeMsg, "Ok");
            }

        } 
    }
}
