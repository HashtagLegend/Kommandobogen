using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;
using KommandoBogApp.ViewModel;

namespace KommandoBogApp.Handler
{
    class ActivityHandler
    {
        public ActivityViewModel ActivityViewModel { get; set; }

        public ActivityHandler(ActivityViewModel activityViewModel)
        {
            ActivityViewModel = activityViewModel;
        }

        public void CreateActivity()
        {
            Activity activity = new Activity(ActivityViewModel.ViewDateFrom, ActivityViewModel.ViewDateTo, ActivityViewModel.ViewKommentar, ActivityViewModel.ViewNavn, ActivityViewModel.ViewColor);
            ActivityViewModel.ActivityList.AddUser(activity);
        }
    }
}