using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace extrapoints_1_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void Info(object ob, EventArgs ar)
        {
            await DisplayAlert("More info", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In " +
                "imperdiet lacinia viverra. Donec eros nisl, iaculis vitae iaculis sed, imperdiet a diam. " +
                "Pellentesque laoreet dolor hendrerit faucibus placerat. Nullam finibus tortor quis maximus sodales. " +
                "Sed metus ex, sagittis nec metus sit amet, sodales cursus nunc. In venenatis velit ligula, et sollicitudin " +
                "nunc tempor id. Nunc fermentum, arcu at semper hendrerit, augue libero bibendum magna, ac ultrices lacus " +
                "lectus id urna. Sed sodales lacus posuere arcu mollis feugiat. Nam et ex massa. Etiam at quam non tortor bibendum " +
                "consectetur. Mauris semper enim eros, vitae sagittis neque posuere at. Quisque feugiat, quam sit amet scelerisque " +
                "gravida, erat tellus pellentesque diam, ac auctor libero dolor accumsan purus.", "Ok");
        }
    }
}