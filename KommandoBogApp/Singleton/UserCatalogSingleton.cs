﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Persistency;

namespace KommandoBogApp.Singleton
{
    public class UserCatalogSingleton
    {
        public int HasLoadFromDBRun = 0;
        private static UserCatalogSingleton _instance = new UserCatalogSingleton();
        //Design pattern singleton som kun oprettes 1 gang
        public static UserCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new UserCatalogSingleton()); }
        }

        public ObservableCollection<User> UserList { get; set; }

        public ObservableCollection<User> SearchUserList { get; set; }

        public ObservableCollection<Afdeling> AfdelingList { get; set; }

        public ObservableCollection<string> UserTypeList { get; set; }

        public User LoginUser { get; set; }

        private UserCatalogSingleton()
        {
            SearchUserList = new ObservableCollection<User>();
            UserList = new ObservableCollection<User>();
            AddAfdelinger();
            UserTypeList = new ObservableCollection<string>();
            ActivityDate.id = 0;
            UserTypeList.Add("Regular");
            UserTypeList.Add("Leader");
            UserTypeList.Add("Admin");
            AddUser(new User("123", "test", "test", "test", "test", "test"));

            LoadUsers();

        }

        private async void AddAfdelinger()
        {
                AfdelingList = await AfdelingPersistency.LoadAfdelinger();
        }

        public void AddUser(User user)
        {
            UserList.Add(user);
            UserPersistency.SaveUsers(user);
        }


        public void RemoveUser(User user)
        {
            UserList.Remove(user);
        }

        public async void LoadUsers()
        {
            if (HasLoadFromDBRun == 0)
            {
                UserList.Clear();
                UserList = await UserPersistency.LoadUsers();
                HasLoadFromDBRun++;
            }
        }
        //Udvider load fra DB for at få dates koblet sammen med aktivitet 
        public async void LoadActivitiesFromDB()
        {
            DateTimeOffset dateWithDateTimeOffset;
                
                    ActivitySingleton.Instance.ActivityList.Clear();
                
                if (UserList != null)
                {
                    var Dates = await DatesPersistency.LoadDates();
                    List<Activity> newActivities = await ActivityPersistency.LoadActivities();
                    foreach (var activity in newActivities)
                    {
                        Debug.WriteLine("REEE1");
                        foreach (var user in UserList)
                        {
                            foreach (var afdeling in AfdelingList)
                            {
                                if (user.AfdId == afdeling.AfdId.ToString())
                                {
                                    user.AfdNavn = afdeling.Navn;
                                }
                            }    

                            Debug.WriteLine("REEE2");
                            if (user.MaNummer == activity.MaNummer)
                            {
                                if (activity.Color == "Firebrick")
                                    activity.color = ActivityHandler.Color.Firebrick;
                                if (activity.Color == "Blue")
                                    activity.color = ActivityHandler.Color.Blue;
                                if (activity.Color == "DarkGreen")
                                    activity.color = ActivityHandler.Color.DarkGreen;
                                if (activity.Color == "Orange")
                                    activity.color = ActivityHandler.Color.Orange;
                                activity.ColorString();

                                activity.Initializelist();
                                foreach (var dates in Dates)
                                {
                                    if (activity.ID == dates.ActivityID)
                                    {

                                        if (DateTimeOffset.TryParse(dates.DatesTimeOffset, out dateWithDateTimeOffset))
                                        {
                                        activity.Dates.Add(DateTimeOffset.Parse(dates.DatesTimeOffset));
                                        }
                                        if (dates.ID >= ActivityDate.id)
                                        {
                                            ActivityDate.id = dates.ID;
                                        }
                                        activity.DatesID.Add(dates.ID);
                                    }
                                }
                                
                                user.Activities.Add(activity);
                            }
                        }
                        Activity.id++;
                    }

            }
        }
    }
}
