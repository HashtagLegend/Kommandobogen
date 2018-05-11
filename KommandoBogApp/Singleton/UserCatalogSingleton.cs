using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ObservableCollection<Afdeling> AfdelingList { get; set; }

        public ObservableCollection<string> UserTypeList { get; set; }

        private UserCatalogSingleton()
        {
            UserList = new ObservableCollection<User>();
            AfdelingList = new ObservableCollection<Afdeling>();
            AfdelingList.Add(new Afdeling("Q"));
            AfdelingList.Add(new Afdeling("J"));
            AfdelingList.Add(new Afdeling("Pallemans Combobox"));
            UserTypeList = new ObservableCollection<string>();
            UserTypeList.Add("Regular");
            UserTypeList.Add("Leader");
            UserTypeList.Add("Admin");

        }

        public void AddUser(User user)
        {
            UserList.Add(user);
        }


        public void RemoveUser(User user)
        {
            UserList.Remove(user);
            user.Afd.AfdelingList.Remove(user);
        }

        
    }
}
