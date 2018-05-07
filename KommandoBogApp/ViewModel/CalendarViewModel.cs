using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;
using KommandoBogApp.View;

namespace KommandoBogApp.ViewModel
{
    class CalendarViewModel
    {
        public static IList<DateTimeOffset> CalendarViewSelectedDates { get; set; } 

        public CalendarViewModel()
        {
            CalendarDates = new ObservableCollection<DateTime>();
            ActivitySingleton = ActivitySingleton.Instance;
        }

        public ActivitySingleton ActivitySingleton { get; set; }

        public ObservableCollection<DateTime> CalendarDates { get; set; }

        public List<DateTime> CurrentDatesToActivity()
        {
            foreach (var VARIABLE in CalendarViewSelectedDates)
            {
                var dates = new DateTime();
                

                var CurrentDatesToActivityList = new List<DateTime>();
                CurrentDatesToActivityList.Add(dates);
            }
            return CurrentDatesToActivity();
        }

        public void SortActivities()
        {
            foreach (var VARIABLE in CalendarViewSelectedDates)
            {
                
            }
        }

    }
}
