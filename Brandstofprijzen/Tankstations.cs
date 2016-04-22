using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandstofprijzen
{
    public class Tankstations : INotifyPropertyChanged
    {
        public Tankstations()
        {
            this.Items = new ObservableCollection<Tankstation>();

            Tankstation tankstation = new Tankstation();
            tankstation.naam = "Bouts";
            tankstation.adres = "Scheepvaartskaai 16";
            tankstation.Prijs95 = 1.21;
            tankstation.Prijs98 = 1.38;
            tankstation.PrijsDiesel = 1.02;
            this.Items.Add(tankstation);
            tankstation = new Tankstation();
            tankstation.naam = "Bouts2";
            tankstation.adres = "Scheepvaartskaai 22";
            tankstation.Prijs95 = 1.25;
            tankstation.Prijs98 = 1.45;
            tankstation.PrijsDiesel = 1.05;
            this.Items.Add(tankstation);

        }

        public ObservableCollection<Tankstation> Items { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
