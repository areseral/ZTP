using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hurtownia
{
    class Zamowienia : IEnumerable
    {
        List<Produkt> lista = new List<Produkt>();
        List<Zamowienie> listazamowien = new List<Zamowienie>();

        private BazaImpl baza;
        //StringBuilder faktura;

        public Zamowienia() { 
            baza = new SQLlite();
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int i = 0; i < lista.Count; i++)
            {
                yield return lista[i];
            }
        }

        public void zbudujFakture(int id_zamow)
        {
            StringBuilder html_kod;
            BudowniczyFaktury faktura = new BudowniczyWydrukFakturyHTML();
            faktura.dodajWiersze(pobierzProduktyzZamowienia(id_zamow));
            html_kod = faktura.pobierzFakuture();
            string path = @""+id_zamow+".html";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(html_kod.ToString());
            }  


        }

        public void pokazFakture(int id_zamow)
        { 
            //odpalanie faktury
            System.Diagnostics.Process.Start("http://"+id_zamow+".html");
        }

        public void ZlozZamowienie(Collection<Produkt> dane, int id)
        {
            if (dane.Count > 0)
            {
                DataTable dt;
                DateTime dateDate = DateTime.UtcNow;
                
                int i, k=0;
                foreach(Produkt p in dane)
                {
                    lista.Add(p);
                }
                //generowanie indywidualnego id zamówienia
                int idz = id*100000000+  dateDate.Hour * 100000 + dateDate.Minute * 100 + dateDate.Second;

                foreach(Produkt pp in lista)
                {
                    baza.Create("INSERT INTO [Zamowienie] (id_zamowienie,id_user,id_produkt,ilosc,data) VALUES ("+ idz +","+ id +","+ pp.Id +","+ pp.Sztuk +",'"+ dateDate.TimeOfDay +"')");
                }
                
                dt = baza.Read("SELECT * FROM Placowka WHERE id_user =" + k);
                if (dt != null)
                {
                    foreach (DataRow row2 in dt.Rows)
                    {
                        Int32.TryParse(row2["Id"].ToString(), out i);
                        //placOkno = new PlacPanel(i, k, row2["imie"].ToString(), row2["nazwisko"].ToString(), row2["nip"].ToString(), row2["ulica"].ToString(), row2["kodpocztowy"].ToString(), row2["miejscowosc"].ToString());
                    }
                }
                lista.Clear();
            }
        }

        public List<Produkt> pobierzProduktyzZamowienia(int id)
        {
            List<Produkt> danezam = new List<Produkt>();
            DataTable dt;
            Int32[] tab = new Int32[6];
            dt = baza.Read("SELECT * FROM Produkt, Zamowienie  WHERE Zamowienie.id_zamowienie =" + id +" AND Zamowienie.id_produkt = Produkt.Id");
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int k = 0, i = 0, s = 0;
                    Int32.TryParse(row["kategoria"].ToString(), out k);
                    Int32.TryParse(row["id"].ToString(), out i);
                    Int32.TryParse(row["ilosc"].ToString(), out s);
                    float c = float.Parse(row["cena"].ToString());
                    danezam.Add(new Produkt(row["nazwa"].ToString(), row["opis"].ToString(), k, i, c, s));
                }
            }
            return danezam;
        }
        
        public Collection<Zamowienie> pobierzZamowienia(int id, bool all)
        {
            Collection<Zamowienie> danezam = new ObservableCollection<Zamowienie>();
            DataTable dt;
            int powtorka = -1;
            Int32 []tab =  new Int32[6];
            dt = baza.Read("SELECT * FROM Zamowienie WHERE id_user =" + id);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Int32.TryParse(row["Id"].ToString(), out tab[0]);
                    Int32.TryParse(row["id_zamowienie"].ToString(), out tab[1]);
                    Int32.TryParse(row["id_user"].ToString(), out tab[2]);
                    Int32.TryParse(row["id_produkt"].ToString(), out tab[3]);
                    Int32.TryParse(row["ilosc"].ToString(), out tab[4]);
                    Int32.TryParse(row["realizacja"].ToString(), out tab[5]);
                    DateTime data = DateTime.Parse(row["data"].ToString());

                    if (powtorka != tab[1] && !all)
                    { 
                        powtorka = tab[1];
                        danezam.Add(new Zamowienie(tab[0], tab[1], tab[2], tab[3],tab[4], data, tab[5]));
                    }
                }
            }

            return danezam;
        }

        public void zapiszPamiatke(Collection<Produkt> dane)
        {
            foreach (Produkt p in dane)
            {
                lista.Add(p);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Produkt>));
            TextWriter textWriter = new StreamWriter(@"pamiatka.xml");
            serializer.Serialize(textWriter, lista);
            textWriter.Close();
            lista.Clear();
        }

        public Collection<Produkt> pobierzPamiatke()
        {
            Collection<Produkt> dane = new ObservableCollection<Produkt>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Produkt>));
            TextReader textReader = new StreamReader(@"pamiatka.xml");
            lista = (List<Produkt>)deserializer.Deserialize(textReader);
            textReader.Close();
            foreach (Produkt p in lista)
            {
                dane.Add(p);
            }
            lista.Clear();
            return dane;
        }

        


    }
}
