﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Microsoft.Xaml.Interactions.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KommandoBogApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarViewView : Page
    {
        //Kode behind for at benytte fuld funktionalietet i vores calender view
        public ActivitySingleton ActivitiySingleton { get; set; }

        public ActivityViewModel ActivityViewModel { get; set; }

        public UserCatalogSingleton UserSingleton { get; set; }

        public static bool UILoading = true;

        public CalendarViewView()
        {
            this.InitializeComponent();
            ActivitiySingleton = ActivitySingleton.Instance;
            ActivityViewModel = new ActivityViewModel();
            UserSingleton = UserCatalogSingleton.Instance;
            Opret.Click += Opret_OnClick;
            MAFraloginTest.Text = UserHandler.UserVM.UserCatalogSingleton.LoginUser.MaNummer;
            NavnFraLoginTest.Text = UserHandler.UserVM.UserCatalogSingleton.LoginUser.Navn;
        }

        public static List<DateTimeOffset> DateSelected { get; set; }
        //Alle vores observers
        private void CalendarView_OnSelectedDatesChanged(object sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            ActivityHandler.CalendarViewSelectedDates = CalendarView1.SelectedDates;
            ActivityViewModel.ShowFilteredList();
        }

        public void CalenderViewViewUpdate()
        {
            ActivityHandler.CalendarViewSelectedDates = CalendarView1.SelectedDates;
        }

        public void CalendarView_CalendarViewDayItemChanging(CalendarView sender,
            CalendarViewDayItemChangingEventArgs args)
        {
            var currentActivities = new List<Activity>();
            var stringdatesVagt = new List<string>();
            var stringdatesKursus = new List<string>();
            var stringdatesFri = new List<string>();
            var stringdatesFerie = new List<string>();
            if (UserSingleton.LoginUser.Activities != null)
            {
                if (UILoading)
                {
                        foreach (var activity in UserSingleton.LoginUser.Activities)
                        {
                            if (activity.Dates != null)
                            {
                                foreach (var dates in activity.Dates)
                                {

                                    if (dates.DateTime.Date == args.Item.Date.DateTime.Date)
                                    {
                                        currentActivities.Add(activity);
                                    }

                                }

                            }
                        }
                }


            }

            var CalendarTime = args.Item.Date.DateTime.ToString("yyyy-MM-dd");

            foreach (var VARIABLE in currentActivities)
            {
                foreach (var Dates in VARIABLE.Dates)
                {
                    ActivityHandler.Color c = VARIABLE.color;
                    switch (c)
                    {
                        case ActivityHandler.Color.Blue:
                            stringdatesVagt.Add(Dates.DateTime.ToString("yyyy-MM-dd"));
                            break;

                        case ActivityHandler.Color.DarkGreen:
                            stringdatesKursus.Add(Dates.DateTime.ToString("yyyy-MM-dd"));
                            break;

                        case ActivityHandler.Color.Firebrick:
                            stringdatesFri.Add(Dates.DateTime.ToString("yyyy-MM-dd"));
                            break;

                        case ActivityHandler.Color.Orange:
                            stringdatesFerie.Add(Dates.DateTime.ToString("yyyy-MM-dd"));
                            break;
                    }


                }
            }

            var densityColors = new List<Color>();

            if (stringdatesVagt.Distinct().Contains(CalendarTime))
            {
                Debug.WriteLine(CalendarTime);
                //args.Item.Background = new SolidColorBrush(Colors.Red);
                densityColors.Add(Colors.Blue);
                args.Item.SetDensityColors(densityColors);

            }

            if (stringdatesKursus.Distinct().Contains(CalendarTime))
            {
                Debug.WriteLine(CalendarTime);
                //args.Item.Background = new SolidColorBrush(Colors.Red);
                densityColors.Add(Colors.DarkGreen);
                args.Item.SetDensityColors(densityColors);

            }

            if (stringdatesFri.Distinct().Contains(CalendarTime))
            {
                Debug.WriteLine(CalendarTime);
                //args.Item.Background = new SolidColorBrush(Colors.Red);
                densityColors.Add(Colors.Firebrick);
                args.Item.SetDensityColors(densityColors);

            }

            if (stringdatesFerie.Distinct().Contains(CalendarTime))
            {
                Debug.WriteLine(CalendarTime);
                //args.Item.Background = new SolidColorBrush(Colors.Red);
                densityColors.Add(Colors.Orange);
                args.Item.SetDensityColors(densityColors);

            }

        }

        private void CalendarView1_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            CalendarView1.SelectionMode = CalendarViewSelectionMode.Multiple;
        }

        private void CalendarView1_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            CalendarView1.SelectionMode = CalendarViewSelectionMode.Single;
        }

        private async void Opret_OnClick(object sender, RoutedEventArgs e)
        {
            UILoading = false;
            if (SetActivity.SelectionBoxItem != null)
            {
                if (SetActivity.SelectionBoxItem.Equals("Ferie"))
                {
                    ActivityViewModel.Handler.CreateActivity(ActivityHandler.Color.Orange);
                }
                else if (SetActivity.SelectionBoxItem.Equals("Vagt"))
                {
                    ActivityViewModel.Handler.CreateActivity(ActivityHandler.Color.Blue);
                }
                else if (SetActivity.SelectionBoxItem.Equals("Kursus"))
                {
                    ActivityViewModel.Handler.CreateActivity(ActivityHandler.Color.DarkGreen);
                }
                else if (SetActivity.SelectionBoxItem.Equals("Fri"))
                {
                    ActivityViewModel.Handler.CreateActivity(ActivityHandler.Color.Firebrick);
                }



                int i = 1;
                if (ActivityHandler.CalendarViewSelectedDates != null)
                {
                    i = ActivityHandler.CalendarViewSelectedDates.Count;
                }


                await Task.Delay(TimeSpan.FromSeconds(3 + i));
                Frame.Navigate(typeof(KommandoBogApp.View.CalendarViewView));
                if (i == 1)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1.5 + i));
                }
                if (i > 1)
                    await Task.Delay(TimeSpan.FromSeconds(1.5 + 1.5 * i));
                Frame.Navigate(typeof(KommandoBogApp.View.CalendarViewView));
            }
        }

        public void LeavingPage(object sender, RoutedEventArgs e)
        {
            if (ActivityHandler.CalendarViewSelectedDates != null)
            {
                ActivityHandler.CalendarViewSelectedDates.Clear();
            }
        }

        public async void SelfDestruct(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

            });
            ActivityHandler.CalendarViewSelectedDates.Clear();
            this.Frame.Navigate(typeof(KommandoBogApp.View.CalendarViewView));
        }

        public void NavigateToPageOpretBruger(object sender, RoutedEventArgs e)
        {
            if (UserSingleton.LoginUser.UserType == "Admin")
            {
                LeavingPage(sender, e);
                this.Frame.Navigate(typeof(KommandoBogApp.View.CreateUserView));
            }
        }
    }
}
