using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace tipsAndTricks.ViewModels
{
    class TipsAndTricksMainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public TipsAndTricksMainPageViewModel()
        {

        }
    }
}
