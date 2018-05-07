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
        public ActivityViewModel ActivityVM { get; set; }

        public ActivityHandler(ActivityViewModel activityVm)
        {
            ActivityVM = activityVm;
        }

        public void CreateActivity()
        {
            if (ActivityVM.ViewActivityType == "Ferie")
            {
                ActivityVM.ActivityList.AddActivity(new Ferie(ActivityVM.ViewDateFrom, ActivityVM.ViewDateTo, ActivityVM.ViewKommentar, ActivityVM.ViewNavn, ActivityVM.ViewColor, ActivityVM.ViewActivityType));
            }
            else if (ActivityVM.ViewActivityType == "Kursus")
            {
                ActivityVM.ActivityList.AddActivity(new Kursus(ActivityVM.ViewDateFrom, ActivityVM.ViewDateTo, ActivityVM.ViewKommentar, ActivityVM.ViewNavn, ActivityVM.ViewColor, ActivityVM.ViewActivityType));
            }
            else if (ActivityVM.ViewActivityType == "Fri")
            {
                ActivityVM.ActivityList.AddActivity(new Fri(ActivityVM.ViewDateFrom, ActivityVM.ViewDateTo, ActivityVM.ViewKommentar, ActivityVM.ViewNavn, ActivityVM.ViewColor, ActivityVM.ViewActivityType));
            }
            else if (ActivityVM.ViewActivityType == "Vagt")
            {
                ActivityVM.ActivityList.AddActivity(new Vagt(ActivityVM.ViewDateFrom, ActivityVM.ViewDateTo, ActivityVM.ViewKommentar, ActivityVM.ViewNavn, ActivityVM.ViewColor, ActivityVM.ViewActivityType));
            }


        }
    }
}