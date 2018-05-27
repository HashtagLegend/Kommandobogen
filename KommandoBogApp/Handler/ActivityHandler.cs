using System;
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
            await Task.Run(async () =>
            {
                UserCatalogSingleton.Instance.LoginUser.AddActivity(newActivity);
                await Task.Delay(TimeSpan.FromSeconds(10));
                UserCatalogSingleton.Instance.LoginUser.AddDatesToActivityInDB(newActivity);
                return newActivity;
            });
        }

        public List<DateTimeOffset> CurrentDatesToActivity()
        {
            UseAfterTimeStart = ActivityViewModel.TimeStart;
            UseAfterTimeEnd = ActivityViewModel.TimeEnd;
            var CurrentDatesToActivityList = new List<DateTimeOffset>();
            if (CalendarViewSelectedDates.Count == 1)
            {
                CurrentDatesToActivityList.Add(new DateTimeOffset(DateTime.SpecifyKind(new DateTime(CalendarViewSelectedDates[0].Year, CalendarViewSelectedDates[0].Month, CalendarViewSelectedDates[0].Day, ActivityViewModel.TimeStart.Hours,
                        ActivityViewModel.TimeStart.Minutes, ActivityViewModel.TimeStart.Seconds), DateTimeKind.Utc)));
            }

            else if (CalendarViewSelectedDates != null)
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
                foreach (var VARIABLE in CalendarViewSelectedDates)
                {
                    foreach (var ActivityDates in Activity.Dates)
                    {
                        if (ActivityDates.Date == VARIABLE.Date)
                        {
                            ActivityVM.CalendarOverviewSingleton.ActiveActivityList.Add(Activity);
                        }
                    }

                }
                Activity.ToStringDate();
            }

        }

      
    }
 }