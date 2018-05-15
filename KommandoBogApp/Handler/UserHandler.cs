using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Popups;
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
                Admin admin = new Admin(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail);
                UserVM.UserCatalogSingleton.AddUser(admin);
                AddUserToAfdeling(admin);
                admin.Afd = UserVM.Afdeling;

            }
            else if (UserVM.Type == "Leader")
            {
                Leader leader = new Leader(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail);
                UserVM.UserCatalogSingleton.AddUser(leader);
                AddUserToAfdeling(leader); 
                leader.Afd = UserVM.Afdeling;


            }
            else if (UserVM.Type == "Regular")
            {
                Regular regular= new Regular(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail);
                UserVM.UserCatalogSingleton.AddUser(regular);
                AddUserToAfdeling(regular);
                regular.Afd = UserVM.Afdeling;
            }

        }

        public void DeleteUser()
        {
            UserVM.UserCatalogSingleton.RemoveUser(UserVM.SelectedUser);
        }

        public void AddUserToAfdeling(User user)
        {
            UserVM.Afdeling.AddUserToList(user);
            
        }

        public bool CheckCredentials(string credentials)
        {
            foreach (User user in UserVM.UserCatalogSingleton.UserList)
            {
                if (credentials==user.MaNummer)
                {
                    UserVM.UserCatalogSingleton.LoginUser = user;
                    
                    return true;
                }
            }

            return false;
        }



        
    }
}
