using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandstofprijzen
{
    public class Tankstation : INotifyPropertyChanged
    {
        private string uniqueId;

        public string UniqueId
        {
            get { return uniqueId; }
            set
            {
                if (value != uniqueId)
                {
                    uniqueId = value;
                    NotifyPropertyChanged("UniqueId");
                }
            }
        }

        private string Naam;

        public string naam
        {
            get { return Naam; }
            set { Naam = value;
                NotifyPropertyChanged("naam");
            }
        }

        private string Adres;

        public string adres
        {
            get { return Adres; }
            set { Adres = value;
                NotifyPropertyChanged("adres");
            }
        }

        private double prijs95;

        public double Prijs95
        {
            get { return prijs95; }
            set { prijs95 = value;
                NotifyPropertyChanged("Prijs95");
            }
        }

        private double prijs98;

        public double Prijs98
        {
            get { return prijs98; }
            set { prijs98 = value;
                NotifyPropertyChanged("Prijs98");
            }
        }

        private double prijsDiesel;

        public double PrijsDiesel
        {
            get { return prijsDiesel; }
            set { prijsDiesel = value;
                NotifyPropertyChanged("PrijsDiesel");
            }
        }

        private double prijs;

        public double Prijs
        {
            get { return prijs; }
            set
            {
                prijs = value;
                NotifyPropertyChanged("Prijs");
            }
        }

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
