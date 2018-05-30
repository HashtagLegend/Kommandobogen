using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    public sealed partial class HubTest : Page
    {
        public static DateTime ShownMonth {get; set; }
        public List<int> ListOfPossibleMonths { get; set; }
        public List<int> ListOfPossibleYears { get; set; }
        public UserCatalogSingleton UserCatalogSingleton { get; set; }
        public ObservableCollection<User> LoadUsersOfThree { get; set; }
        public int Load = 0;
        public int i = 0;

        public HubTest()
        {
            UserViewModel.DatesInMonth = new ObservableCollection<int>();
            UserCatalogSingleton = UserCatalogSingleton.Instance;
            LoadUsersOfThree = new ObservableCollection<User>();
            ShownMonth = DateTime.Today;
            this.InitializeComponent();
            this.Loaded += FixHubTestAcitivities;
            datesInMonth();
            ListOfPossibleMonths = new List<int>();
            FillListOfPossibleMonths();
            ListOfPossibleYears = new List<int>();
            FillListOfPossibleYears();
        }
        //Loader kun et bestemt antal aktiviteer
        private void FixHubTestAcitivities(object sender, RoutedEventArgs e)
        {
            switch (i)
            {
                case 0:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;

                case 1:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;
                case 2:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;
                case 3:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;
                case 4:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;
                case 5:
                    for (int j = 0; j < 2; j++)
                    {
                        if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count > Load)
                        {
                            LoadUsersOfThree.Add(UserHandler.UserVM.UserCatalogSingleton.UserList[Load]);
                            Load++;
                        }
                    }
                    break;

            }

            foreach (var Users in LoadUsersOfThree)
            {
                Users.DaysWithActivities.Clear();
                Users.FillDaysWithActivities();
                foreach (var Activities in Users.Activities)
                {
                    foreach (var Dates in Activities.Dates)
                    {
                        if (Dates.Month == HubTest.ShownMonth.Month && Dates.Year == HubTest.ShownMonth.Year)
                        {
                            Debug.WriteLine(Dates.Day - 1);
                            Users.DaysWithActivities[Dates.Day - 1] = Activities;
                        }
                    }
                }
            }
        }

        public void FillListOfPossibleMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                ListOfPossibleMonths.Add(i);
            }
        }

        public void FillListOfPossibleYears()
        {
            for (int i = 2000; i <= 2100; i++)
            {
                ListOfPossibleYears.Add(i);
            }
        }

        public void datesInMonth()
        {
            UserViewModel.DatesInMonth.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(ShownMonth.Year, ShownMonth.Month); i++)
            {
                UserViewModel.DatesInMonth.Add(i);
            }
        }

        private void iOneUp(object sender, RoutedEventArgs e)
        {
            i++;
            FixHubTestAcitivities(sender, e);
        }

        private void MonthPlusOne(object sender, RoutedEventArgs e)
        {
            if (ShownMonth.Month == 12)
            {
                ShownMonth.AddYears(1);
            }
            ShownMonth = ShownMonth.AddMonths(1);
            
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
            YearShownTextBox.Text = ShownMonth.Year.ToString();
        }

        private void MonthMinusOne(object sender, RoutedEventArgs e)
        {
            if (ShownMonth.Year == 1)
            {
                ShownMonth.AddYears(-1);
            }
            ShownMonth = ShownMonth.AddMonths(-1);
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
            YearShownTextBox.Text = ShownMonth.Year.ToString();
        }

        private void MonthShownTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MonthShownTextBox.Text != String.Empty)
            {
                if (ListOfPossibleMonths.Contains(Int32.Parse(MonthShownTextBox.Text)))
                {
                    ShownMonth = ShownMonth.AddMonths(-ShownMonth.Month);
                    ShownMonth = ShownMonth.AddMonths(Int32.Parse(MonthShownTextBox.Text));
                    FixHubTestAcitivities(sender, e);
                    datesInMonth();
                    MonthYearError.Text = "";
                }
                else
                {
                    MonthYearError.Text = "Måneden er ikke inden for Kalenders rækkevidde";
                }
            }
        }
        private void YearShownTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (YearShownTextBox.Text != String.Empty)
            {
                if (Int32.Parse(YearShownTextBox.Text) >= 2000 && Int32.Parse(YearShownTextBox.Text) <= 2100)
                {
                    if (ListOfPossibleYears.Contains(Int32.Parse(YearShownTextBox.Text)))
                    {
                        ShownMonth = ShownMonth.AddYears(-ShownMonth.Year+1);
                        ShownMonth = ShownMonth.AddYears(Int32.Parse(YearShownTextBox.Text)-1);
                        datesInMonth();
                        MonthYearError.Text = "";
                    }
                }
                else
                {
                    MonthYearError.Text = "Året er ikke inden for Kalenders rækkevidde";
                }
            }
        }

        public void NavigateToPageOpretBruger(object sender, RoutedEventArgs e)
        {
            if (UserCatalogSingleton.LoginUser.UserType == "Admin")
            {
                this.Frame.Navigate(typeof(KommandoBogApp.View.CreateUserView));
            }
        }

    }
}
