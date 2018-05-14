using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation.Peers;

namespace KommandoBogApp.Model
{
    public class Regular : User
    {

        public Regular(string maNummer, string navn, string tlf, string adresse, string email) : base(maNummer, navn, tlf, adresse, email)
        {
            UserType = "Regular";
        }

       

    }
}
