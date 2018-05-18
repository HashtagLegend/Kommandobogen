using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using System.Windows.Input;
using KommandoBogApp.Annotations;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.RelayCommands;
using KommandoBogApp.Singleton;
using KommandoBogApp.View;
using KommandoBogApp.View;
using User = KommandoBogApp.Model.User;

namespace KommandoBogApp.ViewModel
{
    public class UserViewModel
    {

        public string navn { get; set; }
        public UserCatalogSingleton UserCatalogSingleton { get; set; }
        public string ViewMaNr { get; set; }
        public string ViewNavn { get; set; }
        public string ViewTlf { get; set; }
        public string ViewAdresse { get; set; }
        public string ViewEmail { get; set; }
        public string Type { get; set; }
        public Afdeling Afdeling { get; set; }
        public User SelectedUser { get; set; }
        public ActivityViewModel ActivityViewModel { get; set; }
        public static ObservableCollection<int> DatesInMonth { get; set; }
        public static string CurrentShownMonth { get; set; }
        public static string CurrentShownYear { get; set; }
        public ObservableCollection<User> ShownUsers { get; set; }
        public string FirstShownStartingLetters { get; set; }
        public UserHandler UserHandler { get; set; }
        public static string ViewSearch { get; set; }

        public string ViewPassword { get; set; }

        public UserHandler Handler { get; set; }


        public UserViewModel()
        {
            navn = KnownUserProperties.FirstName;
            Debug.WriteLine(navn);
            ActivityViewModel = new ActivityViewModel();
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

            Handler = new UserHandler(this);
            ShownUsers = new ObservableCollection<User>();
            SetCurrentShownMonth();

            List<DateTimeOffset> Dates = new List<DateTimeOffset>();
            Dates.Add(DateTimeOffset.Now);
            User NewUser = new User("01", "Ole", "26891221", "Afrika", "Shit@Hotmail.com");
            NewUser.Activities.Add(new Activity(Dates, "I Australien", "Ole", ActivityHandler.Color.Blue));
            User NewUser1 = new User("02", "Henrik", "26891221", "Afrika", "Shit@Hotmail.com");
            NewUser1.Activities.Add(new Activity(Dates, "I Australien", "Ole", ActivityHandler.Color.Orange));
            User NewUser2 = new User("01", "Ole", "26891221", "Afrika", "Shit@Hotmail.com");
            NewUser2.Activities.Add(new Activity(Dates, "I Australien", "Ole", ActivityHandler.Color.Blue));
            UserCatalogSingleton.AddUser(NewUser);
            UserCatalogSingleton.AddUser(NewUser1);

            Handler.FixDaysWithActivities();
        }

        public static void SetCurrentShownMonth()
        {
            CurrentShownMonth = HubTest.ShownMonth.Month.ToString();
            CurrentShownYear = HubTest.ShownYear.Year.ToString();
        }



        #endregion
        
    }
}
