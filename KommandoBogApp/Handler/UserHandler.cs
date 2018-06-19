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
        //Vi har alt over user metoder og funktionalitet i denne klasse
        public static UserViewModel UserVM { get; set; }

        

        public UserHandler(UserViewModel uSW)
        {
            UserVM = uSW;
        }
        //Opretter bruger alt efter hvilken type
        public void CreateUser()
        {
            bool userExists = false;

            foreach (var user in UserCatalogSingleton.Instance.UserList)
            {
                if (user.MaNummer == UserVM.ViewMaNr)
                {
                    userExists = true;
                }
            }

            

            if (userExists != true)
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
                    Regular regular = new Regular(UserVM.ViewMaNr, UserVM.ViewNavn, UserVM.ViewTlf, UserVM.ViewAdresse, UserVM.ViewEmail, UserVM.ViewPassword);
                    regular.AfdNavn = UserVM.Afdeling.Navn;
                    regular.AfdId = UserVM.Afdeling.AfdId.ToString();
                    UserVM.UserCatalogSingleton.AddUser(regular);
                    AddUserToAfdeling(regular);
                    
                }
            }
        }

       

        //Sletter en given bruger
        public async void DeleteUser()
        {
            int UserSpotInList = 0;
            await Task.Run(async () =>
            {
                foreach (var user in UserVM.UserCatalogSingleton.UserList)
                {
                    if (user == UserViewModel.SelectedUser)
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
                await Task.Delay(TimeSpan.FromSeconds(1));
            });

            await Task.Run(async () =>
            {
                foreach (var user in UserVM.UserCatalogSingleton.UserList)
                {
                    if (user == UserViewModel.SelectedUser)
                    {
                        break;
                    }
                    UserSpotInList++;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            });
            
            Debug.WriteLine(UserSpotInList);
            UserPersistency.DeleteUserAsync(UserViewModel.SelectedUser);
            UserVM.UserCatalogSingleton.RemoveUser(UserViewModel.SelectedUser);
        }

        public void AddUserToAfdeling(User user)
        {
            UserVM.Afdeling.AddUserToList(user);
            
        }

        //Bruger til at tjekke om den givne user kan logges ind

        public bool CheckCredentials(string credentials)
        {
            if (UserCatalogSingleton.Instance.UserList == null)
            {
                Login.LoadFromDBGoneWrong = "Somethings not right, and its probably your authentication that is broken";
            }
            else
            {
                foreach (User user in UserVM.UserCatalogSingleton.UserList)
                {
                    if (credentials == user.MaNummer && user.Password == UserViewModel.LoginPassword)
                    {
                        UserVM.UserCatalogSingleton.LoginUser = user;
                        UserVM.UserCatalogSingleton.LoginUser.Activities.Clear();
                        Debug.WriteLine(UserVM.UserCatalogSingleton.LoginUser.ToString());
                        UserVM.UserCatalogSingleton.LoadActivitiesFromDB();
                        return true;
                    }
                    Login.LoadFromDBGoneWrong = "Wrong Username or Password";
                }
            }
            return false;
        }



        
    }
}
