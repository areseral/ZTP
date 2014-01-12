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
    /// Interaction logic for HurtPanel.xaml
    /// </summary>
    public partial class HurtPanel : Window
    {
        Jednostka hurt;
        private Collection<Produkt> dane = new ObservableCollection<Produkt>();

        public HurtPanel()
        {
            InitializeComponent();
            hurt = new Hurtowniaa();
            dane = hurt.produkty.getProdukty();
            this.ListaProdukty.ItemsSource = dane;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BazaImpl inserttest = new SQLlite();
            MessageBox.Show("Dodawanie Click");
            //inserttest.Create("INSERT INTO [Uzytkownik] (login,haslo,email,rola) VALUES ('user3',' + user3 + ','user3@o2.pl','user')");
            //inserttest.Update("UPDATE [Uzytkownik] SET email='update@meil.com' WHERE login='user3'");
            //inserttest.Delete("DELETE FROM [Uzytkownik] WHERE login= 'user3'");
        }
    }
}
