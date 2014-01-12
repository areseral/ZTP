using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hurtownia
{
    /// <summary>
    /// Interaction logic for PlacPanel.xaml
    /// </summary>
    public partial class PlacPanel : Window
    {
        Placowka plac;
        private Collection<Produkt> dane = new ObservableCollection<Produkt>();
        private Collection<Produkt> dane2 = new ObservableCollection<Produkt>();
        private Collection<Zamowienie> daneZamowien = new ObservableCollection<Zamowienie>();

        public PlacPanel()
        {
            InitializeComponent();
            plac = new Placowka();
            dane = plac.produkty.getProdukty();
            daneZamowien = plac.zamow.pobierzZamowienia(plac.id_user,false);
            this.ListaProdukty.ItemsSource = dane;
            this.ListaZamowienie.ItemsSource = dane2;
            this.zamowieniaLista2.ItemsSource = daneZamowien;
        }

        public PlacPanel(int id_u)
        {
            InitializeComponent();
            plac = new Placowka();
            plac.id_user = id_u;
            dane = plac.produkty.getProdukty();
            daneZamowien = plac.zamow.pobierzZamowienia(plac.id_user,false);
            this.ListaProdukty.ItemsSource = dane;
            this.ListaZamowienie.ItemsSource = dane2;
            this.zamowieniaLista2.ItemsSource = daneZamowien;
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            Produkt temp = (Produkt)this.ListaProdukty.SelectedItem;
            temp.Sztuk = Int32.Parse(BoxSztuk.Text);
            dane2.Add(temp);
        }

        private void ButtonUsun_Click(object sender, RoutedEventArgs e)
        {
            dane2.Remove((Produkt)this.ListaZamowienie.SelectedItem);
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            dane2.Clear();
        }

        private void Zloz_Click(object sender, RoutedEventArgs e)
        {
            plac.zamow.ZlozZamowienie(dane2, plac.id_user);
            daneZamowien = plac.zamow.pobierzZamowienia(plac.id_user,false);
            this.zamowieniaLista2.ItemsSource = daneZamowien;
            dane2.Clear();
        }

        private void Zapis_Click(object sender, RoutedEventArgs e)
        {
            plac.zamow.zapiszPamiatke(dane2);
            dane2.Clear();
        }

        private void Odczyt_Click(object sender, RoutedEventArgs e)
        {
            dane2 = plac.zamow.pobierzPamiatke();
            this.ListaZamowienie.ItemsSource = dane2;
        }

        private void ButtonPokazFakture_Click(object sender, RoutedEventArgs e)
        {
            Zamowienie temp = (Zamowienie)this.zamowieniaLista2.SelectedItem;
            if (temp.Realizacja == 0)
            {
                MessageBox.Show("Zamówienie oczekuje na realizację.");
            }
            else if (temp.Realizacja == 1)
            { 
                plac.zamow.pokazFakture(temp.Id_zamowienie);
            }
            else if (temp.Realizacja > 1)
            {
                MessageBox.Show("Zamówienie zostało zniszczone!!! DESTROOYY!!");
            }
            temp = null;

        }

        private void ButtonGeneruj_Click(object sender, RoutedEventArgs e)
        {
            //testowe generowanie faktury, czyli działanie wzroca BUILDER
            Zamowienie temp = (Zamowienie)this.zamowieniaLista2.SelectedItem;
            plac.zamow.zbudujFakture(temp.Id_zamowienie);
        }
    }
}
