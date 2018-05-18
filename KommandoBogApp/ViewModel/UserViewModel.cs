using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KommandoBogApp.Annotations;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.RelayCommands;
using KommandoBogApp.Singleton;
using KommandoBogApp.View;

namespace KommandoBogApp.ViewModel
{
    public class UserViewModel
    {
        
        public UserCatalogSingleton UserCatalogSingleton { get; set; }
        public string ViewMaNr { get; set; }
        public string ViewNavn { get; set; }
        public string ViewTlf { get; set; }
        public string ViewAdresse { get; set; }
        public string ViewEmail { get; set; }
        public string Type { get; set; }
        public Afdeling Afdeling { get; set; }
        public User SelectedUser { get; set; }
        public UserHandler UserHandler { get; set; }
        public static string ViewSearch { get; set; }

        public string ViewPassword { get; set; }


        
        
        public UserViewModel()
        {
            UserCatalogSingleton = UserCatalogSingleton.Instance;
            UserHandler = new UserHandler(this);


            //User NewUser = new User("01", "Ole", "26891221", "Afrika", "Shit@Hotmail.com");
            //UserCatalogSingleton.AddUser(NewUser);
        }
        public static string LoginString { get; set; }
        public static string LoginPassword { get; set; }





        #region ICommands

        private ICommand _createUser;
        private ICommand _deleteUser;

        public ICommand CreateUserCommand
        {
            get { return _createUser ?? (_createUser = new RelayCommand(UserHandler.CreateUser)); }
            set { _createUser = value; }
        }

        public ICommand DeleteUserCommand
        {
            get { return _deleteUser ?? (_deleteUser = new RelayCommand(UserHandler.DeleteUser)); }
            set { _deleteUser = value; }

        }



        #endregion
        
    }
}
