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
            CalendarDates = new ObservableCollection<DateModel>();
            PlaceHolderActivitySingleton = PlaceHolderActivitySingleton.Instance;
        }

        public PlaceHolderActivitySingleton PlaceHolderActivitySingleton { get; set; }

        public ObservableCollection<DateModel> CalendarDates { get; set; }


        public void SortActivities()
        {
            foreach (var VARIABLE in CalendarViewSelectedDates)
            {
                //List<DateTime> dates, string kommentar, string navn, Color color
                PlaceHolderActivitySingleton.AddActivty();
            }
        }

    }
}
