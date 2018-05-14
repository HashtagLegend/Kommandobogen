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

        public ObservableCollection<User> SearchUserList { get; set; }

        public ObservableCollection<Afdeling> AfdelingList { get; set; }

        public ObservableCollection<string> UserTypeList { get; set; }

        public User LoginUser { get; set; }

        private UserCatalogSingleton()
        {
            SearchUserList = new ObservableCollection<User>();
            UserList = new ObservableCollection<User>();
            AfdelingList = new ObservableCollection<Afdeling>();
            AfdelingList.Add(new Afdeling("Q"));
            AfdelingList.Add(new Afdeling("J"));
            AfdelingList.Add(new Afdeling("Pallemans Combobox"));
            UserTypeList = new ObservableCollection<string>();
            UserTypeList.Add("Regular");
            UserTypeList.Add("Leader");
            UserTypeList.Add("Admin");


            User f1 = new Admin("123", "Frederik Wulff", "42489902", "Hasselvej 2 2th", "fwpdanmark@hotmail.com");
            UserList.Add(f1);
            foreach (Afdeling afd in AfdelingList)
            {
                if (afd.Navn == "Q")
                {
                    f1.Afd = afd;
                    afd.AfdelingList.Add(f1);
                }
            }
            User f2 = new Regular("444", "Steffen LArsen", "4242", "Hasselvej 2 2th", "fwpdanmark@hotmail.com");
            UserList.Add(f2);
            foreach (Afdeling afd in AfdelingList)
            {
                if (afd.Navn == "Q")
                {
                    f2.Afd = afd;
                    afd.AfdelingList.Add(f2);
                }
            }



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
