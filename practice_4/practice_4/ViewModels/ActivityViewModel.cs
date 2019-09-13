using practice_4.Models;
using practice_4.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace practice_4.ViewModels
{
    class ActivityViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Activity> ActivityList { get; set; }
        public ICommand GetActivities { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ActivityViewModel()
        {
            GetActivities = new Command(async () =>
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    var prmAPI = RestService.For<IPRMApi>("https://dockpad.xyz");
                    ActivityList = await prmAPI.GetActivities();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Conectivity error", "You have no internet", "ok");
                }
            });
        }
    }
}
