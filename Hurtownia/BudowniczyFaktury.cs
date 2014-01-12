using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    interface BudowniczyFaktury
    {
        void dodajNaglowek();
        void dodajKolumne();
        void dodajWiersze(List<Produkt> lista);
        StringBuilder pobierzFakuture();
    }
}
