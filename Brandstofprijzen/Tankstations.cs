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
        public Tankstations(int index)
        {
            this.Items = new ObservableCollection<Tankstation>();

            Tankstation tankstation = new Tankstation();
            tankstation.UniqueId = Convert.ToString(1);
            tankstation.naam = "Bouts";
            tankstation.adres = "Scheepvaartskaai 15";
            tankstation.Prijs95 = 1.21;
            tankstation.Prijs98 = 1.38;
            tankstation.PrijsDiesel = 1.02;
            switch (index)
            {
                case 1:
                    tankstation.Prijs = tankstation.Prijs95;
                    break;
                case 2:
                    tankstation.Prijs = tankstation.Prijs98;
                    break;
                default:
                    tankstation.Prijs = tankstation.PrijsDiesel;
                    break;
            }
            this.Items.Add(tankstation);
            tankstation = new Tankstation();
            tankstation.UniqueId = Convert.ToString(2);
            tankstation.naam = "Dats 24";
            tankstation.adres = "Genkersteenweg 70";
            tankstation.Prijs95 = 1.25;
            tankstation.Prijs98 = 1.45;
            tankstation.PrijsDiesel = 1.05;
            switch (index)
            {
                case 1:
                    tankstation.Prijs = tankstation.Prijs95;
                    break;
                case 2:
                    tankstation.Prijs = tankstation.Prijs98;
                    break;
                default:
                    tankstation.Prijs = tankstation.PrijsDiesel;
                    break;
            }
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
