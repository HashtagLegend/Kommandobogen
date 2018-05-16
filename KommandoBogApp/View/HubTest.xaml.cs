using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
        public static DateTime ShownYear{ get; set; }
        public List<int> ListOfPossibleMonths { get; set; }
        public List<int> ListOfPossibleYears { get; set; }

        public HubTest()
        {
            UserViewModel.DatesInMonth = new ObservableCollection<int>();
            ShownMonth = DateTime.Today;
            ShownYear = DateTime.Today;
            this.InitializeComponent();
            datesInMonth();
            ListOfPossibleMonths = new List<int>();
            FillListOfPossibleMonths();
            ListOfPossibleYears = new List<int>();
            FillListOfPossibleYears();


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
            if (MonthShownTextBox.Text != String.Empty)
            {
                if (ListOfPossibleMonths.Contains(Int32.Parse(MonthShownTextBox.Text)))
                {
                    ShownMonth = ShownMonth.AddMonths(-ShownMonth.Month);
                    ShownMonth = ShownMonth.AddMonths(Int32.Parse(MonthShownTextBox.Text));
                    UserHandler.FixDaysWithActivities();
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
                        ShownYear = ShownYear.AddYears(-ShownYear.Year+1);
                        ShownYear = ShownYear.AddYears(Int32.Parse(YearShownTextBox.Text)-1);
                        UserHandler.FixDaysWithActivities();
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                List<DateTimeOffset> Dates = new List<DateTimeOffset>();
                Dates.Add(DateTimeOffset.Now);
                User user1 = new User("02", "Henrik", "26891221", "Afrika", "Shit@Hotmail.com");
                user1.Activities.Add(new Activity(Dates, "I Australien", "Ole", ActivityHandler.Color.Orange));
                UserHandler.UserVM.UserCatalogSingleton.AddUser(user1);
            }
        }
    }
}
