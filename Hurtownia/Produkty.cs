using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    class Produkty
    {
        private static Collection<Produkt> dane = new ObservableCollection<Produkt>();

        public Collection<Produkt> getProdukty()
        { 
                DataTable dt;
                SQLlite baza = new SQLlite();
                dt = baza.Read("SELECT * FROM Produkt");

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int k = 0, i = 0;
                        Int32.TryParse(row["kategoria"].ToString(), out k);
                        Int32.TryParse(row["id"].ToString(), out i);
                        float c = float.Parse(row["cena"].ToString());
                        dane.Add(new Produkt(row["nazwa"].ToString(), row["opis"].ToString(), k, i, c));
                    }
                }
                else { return null; }
                return dane;
        }


    }
}
