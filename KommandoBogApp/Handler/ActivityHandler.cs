﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Converter;
using KommandoBogApp.Model;
using KommandoBogApp.Persistency;
using KommandoBogApp.Singleton;
using KommandoBogApp.View;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    public class ActivityHandler
    {
        public TimeSpan UseAfterTimeStart { get; set; }
        public TimeSpan UseAfterTimeEnd { get; set; }
        public ActivityViewModel ActivityVM { get; set; }

        public static IList<DateTimeOffset> CalendarViewSelectedDates { get; set; }

        //public static string StartDate = CalendarViewSelectedDates.First().ToString();
        //public static string EndDate = CalendarViewSelectedDates.First().ToString();

        public enum Color { DarkGreen, Orange, Firebrick, Blue }

        public ActivityHandler(ActivityViewModel activityViewModel)
        {
            ActivityVM = activityViewModel;
        }

        public Color ColorOfActivity(Color color)
        {
            Color c = color;
            switch (c)
            {
                case Color.Blue:
                    return Color.Blue;

                case Color.DarkGreen:
                    return Color.DarkGreen;

                case Color.Firebrick:
                    return Color.Firebrick;

                case Color.Orange:
                    return Color.Orange;

                default:
                    return c;
            }
        }

        public async void CreateActivity(Color color)
        {
            CalendarViewView.UILoading = false;
            int i = 1;
            Activity newActivity = new Activity(CurrentDatesToActivity(), ActivityViewModel.ViewKommentar, ActivityViewModel.ViewNavn, ColorOfActivity(color));
            newActivity.TimeStart = ActivityViewModel.TimeStart.ToString();
            newActivity.TimeEnd = ActivityViewModel.TimeEnd.ToString();
            newActivity.MaNummer = UserCatalogSingleton.Instance.LoginUser.MaNummer;
            var NewTimeEnd = TimeSpan.Parse(newActivity.TimeEnd);
            NewTimeEnd = UseAfterTimeEnd;
            var NewTimeStart = TimeSpan.Parse(newActivity.TimeStart);
            NewTimeStart  = UseAfterTimeStart;
            
            ActivityViewModel.ViewKommentar = null;
            ActivityViewModel.ViewNavn = null;
            UseAfterTimeEnd.Subtract(UseAfterTimeEnd);
            UseAfterTimeStart.Subtract(UseAfterTimeStart);

            if (CalendarViewSelectedDates != null)
            {
                i = i * CalendarViewSelectedDates.Count();
            }
            await Task.Run(async () =>
            {
                UserCatalogSingleton.Instance.LoginUser.AddActivity(newActivity);
                await Task.Delay(TimeSpan.FromSeconds(1 * i));
                UserCatalogSingleton.Instance.LoginUser.AddDatesToActivityInDB(newActivity);


                return newActivity;
            });
            


            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1 * i));
                foreach (var users in UserCatalogSingleton.Instance.UserList)
                {
                    users.Activities.Clear();
                }
                UserCatalogSingleton.Instance.LoginUser.Activities.Clear();
                await Task.Delay(TimeSpan.FromSeconds(2+i));

                UserCatalogSingleton.Instance.LoadActivitiesFromDB();
                return newActivity;
            });

            CalendarViewView.UILoading = true;
        }

        public List<DateTimeOffset> CurrentDatesToActivity()
        {
            if (CalendarViewSelectedDates != null)
            {
                UseAfterTimeStart = ActivityViewModel.TimeStart;
                UseAfterTimeEnd = ActivityViewModel.TimeEnd;
                var CurrentDatesToActivityList = new List<DateTimeOffset>();
                if (CalendarViewSelectedDates.Count == 1)
                {
                    CurrentDatesToActivityList.Add(new DateTimeOffset(DateTime.SpecifyKind(new DateTime(CalendarViewSelectedDates[0].Year, CalendarViewSelectedDates[0].Month, CalendarViewSelectedDates[0].Day, ActivityViewModel.TimeStart.Hours,
                        ActivityViewModel.TimeStart.Minutes, ActivityViewModel.TimeStart.Seconds), DateTimeKind.Utc)));
                }

                else if (CalendarViewSelectedDates.Count >= 2)
                {
                    foreach (var VARIABLE in CalendarViewSelectedDates)
                    {
                        CurrentDatesToActivityList.Add(new DateTimeOffset(DateTime.SpecifyKind(
                            new DateTime(VARIABLE.Year, VARIABLE.Month, VARIABLE.Day, ActivityViewModel.TimeStart.Hours,
                                ActivityViewModel.TimeStart.Minutes, ActivityViewModel.TimeStart.Seconds), DateTimeKind.Utc)));
                    }
                    var lasttime = CurrentDatesToActivityList[CurrentDatesToActivityList.Count - 1];

                    var lastSelectedtime = CalendarViewSelectedDates[CalendarViewSelectedDates.Count - 1];

                    CurrentDatesToActivityList.Remove(lasttime);

                    CurrentDatesToActivityList.Add(new DateTimeOffset(DateTime.SpecifyKind(
                        new DateTime(lastSelectedtime.Year, lastSelectedtime.Month, lastSelectedtime.Day, ActivityViewModel.TimeEnd.Hours,
                            ActivityViewModel.TimeEnd.Minutes, ActivityViewModel.TimeEnd.Seconds), DateTimeKind.Utc)));

                }


                ActivityViewModel.TimeStart.Subtract(ActivityViewModel.TimeStart);
                ActivityViewModel.TimeEnd.Subtract(ActivityViewModel.TimeEnd);
                return CurrentDatesToActivityList;
            }

            return null;
        }

        public List<Activity> CycleThroughActivities(DateTime dateTime)
        {
            List<Activity> ActivityList = new List<Activity>();

            foreach (var Activity in ActivityVM.ActivityList.ActivityList)
            {

                foreach (var DatesOfActivity in Activity.Dates )
                {

                    if (DatesOfActivity == dateTime)
                    {
                       ActivityList.Add(Activity); 
                    }
                }
            }
            return ActivityList;
        }

        public void ShowFilteredList()
        {
            ActivityVM.CalendarOverviewSingleton.ActiveActivityList.Clear();

            foreach (var Activity in UserCatalogSingleton.Instance.LoginUser.Activities)
            {
                foreach (var selectedDate in CalendarViewSelectedDates)
                {
                    if (Activity.Dates != null)
                    {
                        foreach (var ActivityDates in Activity.Dates)
                        {
                            if (ActivityDates.Date == selectedDate.Date)
                            {
                                ActivityVM.CalendarOverviewSingleton.ActiveActivityList.Add(Activity);
                            }
                        }
                    }
                }
                Activity.ToStringDate();
            }

        }

      
    }
 }