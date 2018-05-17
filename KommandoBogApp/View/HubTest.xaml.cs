using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HubTest : Page
    {
        public static DateTime ShownMonth {get; set; }
        public UserCatalogSingleton UserCatalogSingleton { get; set; }

        public HubTest()
        {
            UserViewModel.DatesInMonth = new ObservableCollection<int>();
            UserCatalogSingleton = UserCatalogSingleton.Instance;
            ShownMonth = DateTime.Today;
            this.InitializeComponent();
            datesInMonth();
        }

        public void datesInMonth()
        {
            UserViewModel.DatesInMonth.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(ShownMonth.Year, ShownMonth.Month); i++)
            {
                UserViewModel.DatesInMonth.Add(i);
            }
        }

        private void MonthPlusOne(object sender, RoutedEventArgs e)
        {
            ShownMonth = ShownMonth.AddMonths(1);
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
        }

        private void MonthMinusOne(object sender, RoutedEventArgs e)
        {
            ShownMonth = ShownMonth.AddMonths(-1);
            datesInMonth();
            UserViewModel.SetCurrentShownMonth();
            MonthShownTextBox.Text = ShownMonth.Month.ToString();
        }

        private void MonthShownTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UserHandler.UserVM.Handler.FixDaysWithActivities();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                List<DateTimeOffset> Dates = new List<DateTimeOffset>();
                Dates.Add(DateTimeOffset.Now);
                User NewUser = new User("02", "Henrik", "26891221", "Afrika", "Shit@Hotmail.com");
                NewUser.Activities.Add(new Activity(Dates, "I Australien", "Ole", ActivityHandler.Color.DarkGreen));
                UserCatalogSingleton.AddUser(NewUser);  
            }
        }

        private void UsersShownTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UserHandler.UserVM.Handler.FixDaysWithActivities();
        }

        private void ForwardInNameList(object sender, RoutedEventArgs e)
        {
            if (UserHandler.NamePage < 1)
            {
                UserHandler.NamePage++;
                UserHandler.ShowUsers();
            }
        }
        private void BackInNameList(object sender, RoutedEventArgs e)
        {
            if (UserHandler.UserVM.UserCatalogSingleton.UserList.Count * 0.1 > UserHandler.NamePage)
            {
                UserHandler.NamePage--;
                UserHandler.ShowUsers();
            }
        }
    }
}
