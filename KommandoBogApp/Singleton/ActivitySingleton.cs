using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Handler;
using KommandoBogApp.Model;
using KommandoBogApp.Persistency;
using ActivityType = Windows.Devices.Sensors.ActivityType;

namespace KommandoBogApp.Singleton
{
    public class ActivitySingleton
    {
        private static ActivitySingleton _instance = new ActivitySingleton();

        public static ActivitySingleton Instance
        {
            get { return _instance ?? (_instance = new ActivitySingleton()); }
        }

        public ObservableCollection<Activity> ActivityList { get; set; }
        public ObservableCollection<Model.ActivityType> ActivityTypeList { get; set; }    

        private ActivitySingleton()
        {
            ActivityList = new ObservableCollection<Activity>();
            ActivityTypeList = new ObservableCollection<Model.ActivityType>();
            ActivityTypeList.Add(new Model.ActivityType("Ferie"));
            ActivityTypeList.Add(new Model.ActivityType("Vagt"));
            ActivityTypeList.Add(new Model.ActivityType("Kursus"));
            ActivityTypeList.Add(new Model.ActivityType("Fri"));
            ActivityTypeList.Add(new Model.ActivityType("Seminar"));

        }

        public void AddActivity(Activity activity)
        {
            ActivityList.Add(activity);
            ActivityPersistency.SaveActivity(activity);
            foreach (var dates in activity.Dates)
            {
                var date = new ActivityDate(activity.ID, dates.ToString());
                DatesPersistency.SaveDates(date);
            }
        }

        public void RemoveActivity(Activity activity)
        {
            ActivityList.Remove(activity);
        }

        
    }
}
