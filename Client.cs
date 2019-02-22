using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curier.Model

{



    class Client
    {

        public int ID;
        public string Nume;
        public string Prenume;
        public string Email;
        public string Adresa;
        public string Telefon;


        public Client()
        {

        }
        public Client(int id, string nume,string prenume,string email,string adr,string tel)
        {
            ID = id;
            Nume = nume;
            Prenume = prenume;
            Nume = nume;
            Email = email;
            Adresa = adr;
            Telefon = tel;

        }



    }
}
