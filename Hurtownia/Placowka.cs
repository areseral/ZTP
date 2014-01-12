using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia
{
    class Placowka : Jednostka
    {
        public Zamowienia zamow;
        public String n;
        
        public Placowka() { 
            zamow = new Zamowienia();
        }

        public override void Send()
        {
            throw new NotImplementedException();
        }
        public override void Receive()
        {
            throw new NotImplementedException();
        }


    }
}
