using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curier.Model
{
    class Comanda
    {
        public int ID;
        public int Expeditor;
        public string Descriere;
        public string AdresaDest;

        public Comanda()
        {

        }

        public Comanda(int id,int exp,string des,string adr)
        {
            ID = id;
            Expeditor = exp;
            Descriere = des;
            AdresaDest = adr;

        }

    }
}
