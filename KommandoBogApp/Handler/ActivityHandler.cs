using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    public class ActivityHandler
    {
        public ActivityViewModel ActivityViewModel { get; set; }

        public static IList<DateTimeOffset> CalendarViewSelectedDates { get; set; }

        public ActivityHandler(ActivityViewModel activityViewModel)
        {
            ActivityViewModel = activityViewModel;
        }

        public void CreateActivity()
        {
            Activity activity = new Activity(CurrentDatesToActivity(), ActivityViewModel.ViewKommentar, ActivityViewModel.ViewNavn, ActivityViewModel.ViewColor, ActivityViewModel.ViewHour, ActivityViewModel.ViewMinutes);
            ActivityViewModel.ActivityList.AddUser(activity);
            Debug.WriteLine(ActivityViewModel.Time);
        }

        public List<DateTimeOffset> CurrentDatesToActivity()
        {
            var CurrentDatesToActivityList = new List<DateTimeOffset>();

            foreach (var VARIABLE in CalendarViewSelectedDates)
            {
                CurrentDatesToActivityList.Add(new DateTimeOffset(VARIABLE.Year, VARIABLE.Month, VARIABLE.Day, VARIABLE.Hour, VARIABLE.Minute, VARIABLE.Second, TimeSpan.Zero));
            }
            return CurrentDatesToActivityList;
        }

        public List<Activity> CycleThroughActivities(DateTime dateTime)
        {
            List<Activity> ActivityList = new List<Activity>();

            foreach (var Activity in ActivityViewModel.ActivityList.ActivityList)
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
    }
}