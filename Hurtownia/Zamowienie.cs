using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    class Zamowienie : INotifyPropertyChanged
    {
       
        private int id_, id_zamowienie_, id_user_, id_produkt_, ilosc_, realizacja_;
        private DateTime data_;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                new PropertyChangedEventArgs(property));
        }

        public Zamowienie() { }
        public Zamowienie(int i, int iz, int iu, int ip, int il, DateTime dt, int r) {
           id_ = i;
           id_zamowienie_ = iz;
           id_user_ = iu;
           id_produkt_ = ip;
           ilosc_ = il;
           data_ = dt;
           realizacja_ = r;
        }
      
        public int Id
        {
            get { return id_; }
            set {
                id_ = value; OnPropertyChanged("Id");
            }
        }
       
        public int Id_zamowienie
        {
            get { return id_zamowienie_; }
            set {
                id_zamowienie_ = value; OnPropertyChanged("Id_zamowienie");
            }
        }

        public int Id_user
        {
            get { return id_user_; }
            set
            {
                id_user_ = value; OnPropertyChanged("Id_user");
            }
        }

        public int Id_produkt
        {
            get { return id_produkt_; }
            set
            {
                id_produkt_ = value; OnPropertyChanged("Id_produkt");
            }
        }
       
        public int Ilosc
        {
            get { return ilosc_; }
            set
            {
                ilosc_ = value; OnPropertyChanged("Ilosc");
            }
        }
        
        public DateTime Data
        {
            get { return data_; }
            set {
                data_ = value; OnPropertyChanged("Data");
            }
        }

        public int Realizacja
        {
            get { return realizacja_; }
            set
            {
                realizacja_ = value; OnPropertyChanged("Realizacja");
            }
        }

        public override string ToString()
        {
            return id_ +" " + id_user_ + " " +id_zamowienie_;
        }

    }
}
