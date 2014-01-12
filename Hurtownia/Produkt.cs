using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hurtownia
{
    [Serializable]
    public class Produkt : INotifyPropertyChanged
    {
        private String nazwa_, opis_;
        private int kategoria_, id_, sztuk_;
        private float cena_;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }

        public Produkt() { }
        public Produkt(String n, String o, int k, int i, float c) {
            nazwa_ = n;
            opis_ = o;
            kategoria_ = k;
            id_ = i;
            cena_ = c;
        }
        public Produkt(String n, String o, int k, int i, float c, int s)
        {
            nazwa_ = n;
            opis_ = o;
            kategoria_ = k;
            id_ = i;
            cena_ = c;
            sztuk_ = s;
        }

        [XmlAttribute("ProduktNazwa")]
        public String Nazwa
        {
            get { return nazwa_; }
            set {
                nazwa_ = value; OnPropertyChanged("Nazwa");
            }
        }
        [XmlAttribute("ProduktOpis")]
        public String Opis 
        {
            get { return opis_; }
            set {
                opis_ = value; OnPropertyChanged("Opis");
            }
        }
        [XmlAttribute("ProduktKategoria")]
        public int Kategoria 
        {
            get { return kategoria_; }
            set {
                kategoria_ = value; OnPropertyChanged("Kategoria");
            }
        }
        [XmlAttribute("ProduktId")]
        public int Id
        {
            get { return id_; }
            set {
                id_ = value; OnPropertyChanged("Id");
            }
        }
        [XmlAttribute("ProduktSztuk")]
        public int Sztuk
        {
            get { return sztuk_; }
            set
            {
                sztuk_ = value; OnPropertyChanged("Sztuk");
            }
        }
        [XmlAttribute("ProduktCena")]
        public float Cena
        {
            get { return cena_; }
            set {
                cena_ = value; OnPropertyChanged("Cena");
            }
        }
        public override string ToString()
        {
            return nazwa_ +" " + opis_ + " " +cena_;
        }

    }
}
