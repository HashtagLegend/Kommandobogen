using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
   public class User
    {

        public string MaNummer { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
        public string Adresse { get; set; }
        //public Afdeling Afdeling_ { get; set; }
        public string Email { get; set; }

        public User(string maNummer, string navn, string tlf, string adresse, string email)
        {
            MaNummer = maNummer;
            Navn = navn;
            Tlf = tlf;
            Adresse = adresse;
            Email = email;
        }

        public void CreateActivity()
        {

        }

        public void EditActivity()
        {

        }

        public override string ToString()
        {
            return $"{nameof(MaNummer)}: {MaNummer}, {nameof(Navn)}: {Navn}, {nameof(Tlf)}: {Tlf}, {nameof(Adresse)}: {Adresse}, {nameof(Email)}: {Email}";
        }
    }
}
