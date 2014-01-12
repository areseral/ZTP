using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    abstract class Jednostka
    {
        public Produkty produkty;
        public String imie, nazwisko, nip, ulica, kodpocztowy, miejscowosc;
        public int id, id_user;

        public Jednostka() {
            produkty = new Produkty();
        }


        public abstract void Send();
        public abstract void Receive();

    }
}
