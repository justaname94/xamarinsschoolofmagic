using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tipsAndTricks.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tipsAndTricks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipsAndTricksMainPage : ContentPage
    {
        public TipsAndTricksMainPage()
        {
            InitializeComponent();
            BindingContext = new TipsAndTricksMainPageViewModel();
        }
    }
}