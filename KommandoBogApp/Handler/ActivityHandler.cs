using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Converter;
using KommandoBogApp.Model;
using KommandoBogApp.Singleton;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    class ActivityHandler
    {
        public ActivityViewModel ActivityVM { get; set; }

        public ActivityHandler(ActivityViewModel activityVm)
        {
            ActivityVM = activityVm;
        }

        public void CreateActivity()
        {
            Activity newActivity = new Activity(DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ActivityVM.ViewDateFrom, ActivityVM.ViewTimeFrom), 
                                                DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ActivityVM.ViewDateTo, ActivityVM.ViewTimeTo), 
                                                ActivityVM.ViewKommentar, 
                                                ActivityVM.ViewNavn, 
                                                ActivityVM.ViewColor, 
                                                ActivityVM.ViewActivityType);
            ActivityVM.ActivityList.AddActivity(newActivity);


            //ActivityVM.ActivityList.AddActivity(new Activity(DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ActivityVM.ViewDateFrom, ActivityVM.ViewTimeFrom), DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(ActivityVM.ViewDateTo, ActivityVM.ViewTimeTo), ActivityVM.ViewKommentar, ActivityVM.ViewNavn, ActivityVM.ViewColor, ActivityVM.ViewActivityType));

        }
    }
}