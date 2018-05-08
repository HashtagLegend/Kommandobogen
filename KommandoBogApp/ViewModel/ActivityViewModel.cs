using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.ViewModel
{
    public class ActivityViewModel
    {
        public List<DateTime> Dates { get; set; }
        public static TimeSpan TimeStart { get; set; }
        public static TimeSpan TimeEnd { get; set; }
        public static string ViewKommentar { get; set; }
        public static string ViewNavn { get; set; }
        public DateTime ViewDateTime { get; set; }
        public Color ViewColor { get; set; }
        public ActivitySingleton ActivityList { get; }
        public ActivityHandler Handler { get; set; }
        public CalendarOverviewSingleton CalendarOverviewSingleton { get;}

        public ActivityViewModel()
        {
            ActivityList = ActivitySingleton.Instance;
            CalendarOverviewSingleton = CalendarOverviewSingleton.Instance;
            Handler=new ActivityHandler(this);
        }

        public void CreateActivity(ActivityHandler.Color color)
        {
            Handler.CreateActivity(color);
        }

        public List<Activity> CycleThroughActivitiesForDates(DateTime dateTime)
        {
            return Handler.CycleThroughActivities(dateTime);
        }
       

        public void ShowFilteredList()
        {
            Handler.ShowFilteredList();
        }
    }
}
