using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    public class UserHandler
    {
        public UserViewModel UserVM { get; set; }

        public UserHandler(UserViewModel uSW)
        {
            UserVM = uSW;
        }

        public void CreateUser(string maNummer,string navn, string tlf, string adresse, string email)
        {
            if (UserVM.Type == "Admin")
            {
                UserVM.UserCatalogSingleton.AddUser(new Admin(maNummer,navn,tlf,adresse,email));
            }
            else if (UserVM.Type == "Leader")
            {
                UserVM.UserCatalogSingleton.AddUser(new Leader(maNummer,navn,tlf,adresse,email));
            }
            else if (UserVM.Type == "Regular")
            {
                UserVM.UserCatalogSingleton.AddUser(new Regular(maNummer,navn,tlf,adresse,email));
            }
            
        }
    }
}
