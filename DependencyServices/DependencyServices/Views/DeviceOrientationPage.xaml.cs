using DependencyServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DependencyServices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceOrientationPage : ContentPage
    {
        public DeviceOrientationPage()
        {
            InitializeComponent();
            BindingContext = new DeviceOrientationViewModel();
        }
    }
}