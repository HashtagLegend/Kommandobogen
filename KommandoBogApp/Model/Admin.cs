using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
    public class Admin: User
    {

        public Admin(string maNummer, string navn, string tlf, string adresse, string email) : base(maNummer, navn, tlf, adresse, email)
        {
            UserType = "Admin";
        }

        public void CreateUser()
        {

        }

        public void EditUser()
        {

        }

        
    }
}
