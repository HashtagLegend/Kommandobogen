using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

namespace KommandoBogApp.Singleton
{
    public class CalendarOverviewSingleton
    {
        //Design pattern singleton som kun oprettes 1 gang
        private static CalendarOverviewSingleton _instance = new CalendarOverviewSingleton();

        public static CalendarOverviewSingleton Instance
        {
            get { return _instance ?? (_instance = new CalendarOverviewSingleton()); }
        }

        public ObservableCollection<Activity> ActiveActivityList { get; set; }

        private CalendarOverviewSingleton()
        {
            ActiveActivityList = new ObservableCollection<Activity>();
        }

        public void AddUser(Activity activity)
        {
            ActiveActivityList.Add(activity);
        }

        public void RemoveUser(Activity activity)
        {
            ActiveActivityList.Remove(activity);
        }
    }
}
