using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.RelayCommands;
using KommandoBogApp.Singleton;
using KommandoBogApp.View;
using User = KommandoBogApp.Model.User;

namespace KommandoBogApp.ViewModel
{
    public class UserViewModel
    {
        //Her bliver alle properties bundet fra view til view model
        public UserCatalogSingleton UserCatalogSingleton { get; set; }
        public string ViewMaNr { get; set; }
        public string ViewNavn { get; set; }
        public string ViewTlf { get; set; }
        public string ViewAdresse { get; set; }
        public string ViewEmail { get; set; }
        public string Type { get; set; }
        public Afdeling Afdeling { get; set; }
        public static User SelectedUser { get; set; }
        public ActivityViewModel ActivityViewModel { get; set; }
        public static ObservableCollection<int> DatesInMonth { get; set; }
        public static string CurrentShownMonth { get; set; }
        public static string CurrentShownYear { get; set; }
        public UserHandler UserHandler { get; set; }
        public static string ViewSearch { get; set; }

        public string ViewPassword { get; set; }

        public string ViewMailMessage { get; set; }




        public UserViewModel()
        {

            ActivityViewModel = new ActivityViewModel();
            UserCatalogSingleton = UserCatalogSingleton.Instance;
            UserHandler = new UserHandler(this);
            SetCurrentShownMonth();


            //User NewUser = new User("01", "Ole", "26891221", "Afrika", "Shit@Hotmail.com");
            //UserCatalogSingleton.AddUser(NewUser);
        }
        public static string LoginString { get; set; }
        public static string LoginPassword { get; set; }





        #region ICommands


        private ICommand _deleteUser;
        private ICommand _createUser;

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

        public static void SetCurrentShownMonth()
        {
            CurrentShownMonth = HubTest.ShownMonth.Month.ToString();
            CurrentShownYear = HubTest.ShownMonth.Year.ToString();
        }
        
    }
}
