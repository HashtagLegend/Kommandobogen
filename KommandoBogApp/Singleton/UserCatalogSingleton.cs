using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;
using KommandoBogApp.Persistency;

namespace KommandoBogApp.Singleton
{
    public class UserCatalogSingleton
    {

        private static UserCatalogSingleton _instance = new UserCatalogSingleton();

        public static UserCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new UserCatalogSingleton()); }
        }

        public ObservableCollection<User> UserList { get; set; }

        public ObservableCollection<User> SearchUserList { get; set; }


        public ObservableCollection<string> UserTypeList { get; set; }

        public User LoginUser { get; set; }

        private UserCatalogSingleton()
        {
            SearchUserList = new ObservableCollection<User>();
            UserList = new ObservableCollection<User>();
            LoadUserAsync();
            //UserList.Add(new User("111","Frederik Wulff","42489902","Hasselvej 2 2th","Fwpdanmark@hotmail.com","123","Admin","Afdeling Q"));



        }

        public void AddUser(User user)
        {
            UserList.Add(user);
        }


        public void RemoveUser(User user)
        {
            UserList.Remove(user);
            
        }

        public async Task LoadUserAsync()
        {
            try
            {
                List<User> users = await PersistencyUser.LoadFromJsonAsync();
                foreach (User u in users)
                {
                    UserList.Add(u);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
