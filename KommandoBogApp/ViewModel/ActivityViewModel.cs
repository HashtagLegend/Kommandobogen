using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.ViewModel
{
    public class ActivityViewModel
    {
        public List<DateTime> Dates { get; set; }
        public TimeSpan Time { get; set; }
        public string ViewKommentar { get; set; }
        public string ViewNavn { get; set; }
        public int ViewHour { get; set; }
        public int ViewMinutes { get; set; }
        public DateTime ViewDateTime { get; set; }
        public Color ViewColor { get; set; }
        public ActivitySingleton ActivityList { get; set; }
        public ActivityHandler Handler { get; set; }

        public ActivityViewModel()
        {
            ActivityList = ActivitySingleton.Instance;
            Handler=new ActivityHandler(this);
            
        }

        public void CreateActivity()
        {
            Handler.CreateActivity();
        }

        public List<Activity> CycleThroughActivitiesForDates(DateTime dateTime)
        {
            return Handler.CycleThroughActivities(dateTime);
        }
    }
}
