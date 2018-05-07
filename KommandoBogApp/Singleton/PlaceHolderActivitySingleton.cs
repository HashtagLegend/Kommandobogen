using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

namespace KommandoBogApp.Singleton
{
    public class PlaceHolderActivitySingleton
    {
        private static PlaceHolderActivitySingleton _instance = new PlaceHolderActivitySingleton();

        public static PlaceHolderActivitySingleton Instance
        {
            get { return _instance ?? (_instance = new PlaceHolderActivitySingleton()); }
        }

        public ObservableCollection<Activity> ActivityList { get; set; }

        private PlaceHolderActivitySingleton()
        {
            ActivityList = new ObservableCollection<Activity>();
        }

        public void AddActivty(Activity activity)
        {
            ActivityList.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            ActivityList.Remove(activity);
        }

        //public DateTimeOffset GetActivityDates(DateModel dateModel)
        //{
        //    foreach (var VARIABLE in ActivityList)
        //    {
                
        //    }
        //}

    }
}
