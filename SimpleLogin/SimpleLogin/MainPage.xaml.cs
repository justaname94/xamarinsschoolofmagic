using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleLogin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ///*async */void OnClicked(object ob, EventArgs ar)
        //{
        //    var button = (Button)ob;
        //    textLabel.Text = textBar.Text;
        //    textLabel.TextColor = button.BackgroundColor;
        //    //await DisplayAlert("Hello", "Hello2", "Ok");
        //}

        async void Login(object ob, EventArgs ar)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            
            if (username == null || username == "")
            {
                await DisplayAlert("Error", "User field cannot be empty", "Ok");
            } else if (password == null || password == "")
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
