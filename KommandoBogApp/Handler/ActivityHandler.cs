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
            Activity activity = new Activity(CurrentDatesToActivity(), ActivityViewModel.ViewKommentar, ActivityViewModel.ViewNavn, ActivityViewModel.ViewColor);
            ActivityViewModel.ActivityList.AddUser(activity);
        }

        public List<DateTime> CurrentDatesToActivity()
        {
            var CurrentDatesToActivityList = new List<DateTime>();

            foreach (var VARIABLE in CalendarViewSelectedDates)
            {
                CurrentDatesToActivityList.Add(new DateTime(VARIABLE.Year, VARIABLE.Month, VARIABLE.Day));
            }
            return CurrentDatesToActivityList;
        }

        public List<Activity> CycleThroughActivities(DateTimeOffset dateTimeOffset)
        {
            List<Activity> ActivityList = new List<Activity>();

            foreach (var Activity in ActivityViewModel.ActivityList.ActivityList)
            {

                foreach (var DatesOfActivity in Activity.Dates )
                {
                    DateTimeOffset DatesOfActivityOffset = DateTime.SpecifyKind(DatesOfActivity, DateTimeKind.Utc);

                    if (DatesOfActivityOffset == dateTimeOffset)
                    {
                       ActivityList.Add(Activity); 
                    }
                }
            }
            return ActivityList;
        }
    }
}