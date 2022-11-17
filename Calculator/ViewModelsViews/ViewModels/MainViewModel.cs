using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Globalization;

namespace ViewModelsViews.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public string Comma => CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

        private Calculations model = new Calculations();

        private string display = "";
        public string Display{ get=>display; set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }
    }
}
