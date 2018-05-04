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

        public void CreateUser()
        {
            if (UserVM.Type == "Admin")
            {
                UserVM.UserCatalogSingleton.AddUser(new Admin(UserVM.ViewMaNr,UserVM.ViewNavn,UserVM.ViewTlf,UserVM.ViewAdresse,UserVM.ViewEmail));
            }
            else if (UserVM.Type == "Leader")
            {
                UserVM.UserCatalogSingleton.AddUser(new Leader(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail));
            }
            else if (UserVM.Type == "Regular")
            {
                UserVM.UserCatalogSingleton.AddUser(new Regular(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail));
            }

        }
    }
}
