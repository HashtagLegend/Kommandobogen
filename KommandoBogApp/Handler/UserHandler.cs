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
using KommandoBogApp.Singleton;
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
                admin.AfdNavn = UserVM.Afdeling.Navn;
                admin.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(admin);
                AddUserToAfdeling(admin);

            }
            else if (UserVM.Type == "Leader")
            {
                Leader leader = new Leader(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                leader.AfdNavn = UserVM.Afdeling.Navn;
                leader.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(leader);
                AddUserToAfdeling(leader); 
                


            }
            else if (UserVM.Type == "Regular")
            {
                Regular regular= new Regular(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                regular.AfdNavn = UserVM.Afdeling.Navn;
                regular.AfdId = UserVM.Afdeling.AfdId.ToString();
                UserVM.UserCatalogSingleton.AddUser(regular);
                AddUserToAfdeling(regular);
              
            }

        }

        public async void DeleteUser()
        {
            int UserSpotInList = 0;
            await Task.Run(async () =>
            {
                foreach (var user in UserVM.UserCatalogSingleton.UserList)
                {
                    if (user == UserVM.SelectedUser)
                    {
                        foreach (var activity in user.Activities)
                        {
                            foreach (var dateids in activity.DatesID)
                            {
                                DatesPersistency.DeleteDateAsync(dateids);
                            }
                            ActivityPersistency.DeleteActivityAsync(activity);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
            });

            await Task.Run(async () =>
            {
                foreach (var user in UserVM.UserCatalogSingleton.UserList)
                {
                    if (user == UserVM.SelectedUser)
                    {
                        break;
                    }
                    UserSpotInList++;
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
            });
            
            Debug.WriteLine(UserSpotInList);
            UserPersistency.DeleteEventsAsync(UserVM.SelectedUser);
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
                if (credentials==user.MaNummer && user.Password==UserViewModel.LoginPassword)
                {
                    UserVM.UserCatalogSingleton.LoginUser = user;
                    Debug.WriteLine(UserVM.UserCatalogSingleton.LoginUser.ToString());
                    UserVM.UserCatalogSingleton.LoadActivitiesFromDB();
                    return true;
                }
            }

            return false;
        }



        
    }
}
