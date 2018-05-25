using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Popups;
using KommandoBogApp.Model;
using KommandoBogApp.Persistency;
using KommandoBogApp.View;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    public class UserHandler
    {
        public static UserViewModel UserVM { get; set; }

        public UserHandler(UserViewModel uSW)
        {
            UserVM = uSW;
        }

        public void CreateUser()
        {
          
            if (UserVM.Type == "Admin")
            {
                Admin admin = new Admin(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                admin.Afd = UserVM.Afdeling;
                admin.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(admin);
                AddUserToAfdeling(admin);

            }
            else if (UserVM.Type == "Leader")
            {
                Leader leader = new Leader(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                leader.Afd = UserVM.Afdeling;
                leader.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(leader);
                AddUserToAfdeling(leader); 
                


            }
            else if (UserVM.Type == "Regular")
            {
                Regular regular= new Regular(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                regular.Afd = UserVM.Afdeling;
                regular.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(regular);
                AddUserToAfdeling(regular);
              
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

        public void FixDaysWithActivities()
        {
            if(UserVM.UserCatalogSingleton.UserList != null)
            foreach (var Users in UserVM.UserCatalogSingleton.UserList)
            {
                Users.DaysWithActivities.Clear();
                Users.FillDaysWithActivities();
                foreach (var Activities in Users.Activities)
                {
                    foreach (var Dates in Activities.Dates)
                    {
                        Debug.WriteLine("Month And Year");
                        Debug.WriteLine(Dates.Month);
                        Debug.WriteLine(Dates.Year);
                        Debug.WriteLine(HubTest.ShownMonth.Month);
                        Debug.WriteLine(HubTest.ShownYear.Year);
                        if (Dates.Month == HubTest.ShownMonth.Month && Dates.Year == HubTest.ShownYear.Year)
                        {
                            Debug.WriteLine(Dates.Day - 1);
                            Users.DaysWithActivities[Dates.Day - 1] = Activities;
                        }
                    }
                }
            }
        }

        public bool CheckCredentials(string credentials)
        {
            foreach (User user in UserVM.UserCatalogSingleton.UserList)
            {
                if (credentials==user.MaNummer && user.Password==UserViewModel.LoginPassword)
                {
                    UserVM.UserCatalogSingleton.LoginUser = user;
                    
                    return true;
                }
            }

            return false;
        }



        
    }
}
