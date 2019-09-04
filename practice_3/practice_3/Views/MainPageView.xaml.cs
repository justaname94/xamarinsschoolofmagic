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
    public partial class MainPageView : TabbedPage
    {
        public MainPageView()
        {
            InitializeComponent();
            // Application.Current.MainPage = new MainTabPageView();
        }
    }
}