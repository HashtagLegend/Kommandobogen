using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using KommandoBogApp.Model;
using KommandoBogApp.View;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    public class UserHandler
    {
        public static UserViewModel UserVM { get; set; }
        public static int AmountOfShownUsers { get; set; }
        public static int NamePage { get; set; }

        public UserHandler(UserViewModel uSW)
        {
            UserVM = uSW;
            AmountOfShownUsers = new int();
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

        public void ShowFirstUsers()
        {
            int count = 0;
            foreach (var User in UserVM.UserCatalogSingleton.UserList)
            {
                
                if (count < 13)
                {
                    UserVM.ShownUsers.Add(User);
                    count++;
                }
            }
        }
        public static void ShowUsers()
        {
            int UsersShown = 0;
            if (UserVM.UserCatalogSingleton.UserList.Count >= NamePage*10)
            {
                for (int i = 0; i < 12; i++)
                {
                    UserVM.ShownUsers.Add(UserVM.UserCatalogSingleton.UserList[NamePage+UsersShown]);
                    if (UsersShown < UserVM.UserCatalogSingleton.UserList.Count - 1)
                    {
                        UsersShown++;
                    }
                }

            }
        }
        public void FixDaysWithActivities()
        {
            foreach (var Users in UserVM.ShownUsers)
            {
                Users.DaysWithActivities.Clear();
                Users.FillDaysWithActivities();
                foreach (var Activities in Users.Activities)
                {
                    foreach (var Dates in Activities.Dates)
                    {
                        if (Dates.Month == HubTest.ShownMonth.Month && Dates.Year == HubTest.ShownYear.Year)
                        {
                            Debug.WriteLine(Dates.Day - 1);
                            Users.DaysWithActivities[Dates.Day - 1] = Activities;
                        }
                    }
                }
            }
        }

        public string UpdateNameTextBox()
        {
            char First;
            char Last;
            First = UserVM.ShownUsers.First().Navn[0];
            Last = UserVM.ShownUsers.Last().Navn[0];
            return $"{First} Til {Last}";
        }
    }
}
