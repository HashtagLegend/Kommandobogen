using System;
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

        private static UserCatalogSingleton _instance = new UserCatalogSingleton();

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
            UserTypeList.Add("Regular");
            UserTypeList.Add("Leader");
            UserTypeList.Add("Admin");
          
            LoadUsers();

            //ActivityHandler.LoadActivitiesFromDB();
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
            user.Afd.AfdelingList.Remove(user);
        }

        public async void LoadUsers()
        {
            UserList.Clear();
            UserList = await UserPersistency.LoadUsers();
        }
    }
}
