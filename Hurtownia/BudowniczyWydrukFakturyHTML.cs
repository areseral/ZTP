using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    class BudowniczyWydrukFakturyHTML : BudowniczyFaktury
    {
        StringBuilder html;

        public BudowniczyWydrukFakturyHTML() 
        {
            html = new StringBuilder();
            html.Append("<body>");
            html.Append("<table>");
            html.Append("<tr><td> ID </td><td> Nazwa </td><td> Opis </td><td> Cena </td><td> Ilosc </td><td> Razem </td></tr>");
        }
        //tutaj w nagłówku powinny polecieć dane placówki
        public void dodajNaglowek()
        {
            html.Append("<body>");
            html.Append("<table>");
        }

        public void dodajKolumne()
        {
            throw new NotImplementedException();
        }

        public void dodajWiersze(List<Produkt> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                html.Append("<tr>");
                html.Append("<td>" + lista[i].Id + " </td><td>" + lista[i].Nazwa + "</td><td>" + lista[i].Opis + "</td><td>" + lista[i].Cena + "</td><td>" + lista[i].Sztuk.ToString() + "</td><td>" + (lista[i].Cena*lista[i].Sztuk).ToString() + "</td>");
                html.Append("</tr>");
            }
        }

        public StringBuilder pobierzFakuture()
        {
            html.Append("</table>");
            html.Append("</body>");
            return html;
        }
    }
}
