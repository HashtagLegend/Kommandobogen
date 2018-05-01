using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

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

        private UserCatalogSingleton()
        {
            UserList = new ObservableCollection<User>();
        }

        public void AddUser(User user)
        {
            UserList.Add(user);
        }

        public void RemoveUser(User user)
        {
            UserList.Remove(user);
        }

        
    }
}
