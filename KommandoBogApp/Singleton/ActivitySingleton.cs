﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Model;

namespace KommandoBogApp.Singleton
{
    class ActivitySingleton
    {
        private static ActivitySingleton _instance = new ActivitySingleton();

        public static ActivitySingleton Instance
        {
            get { return _instance ?? (_instance = new ActivitySingleton()); }
        }

        public ObservableCollection<Activity> ActivityList { get; set; }

        private ActivitySingleton()
        {
            ActivityList = new ObservableCollection<Activity>();
        }

        public void AddActivity(Activity activity)
        {
            ActivityList.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            ActivityList.Remove(activity);
        }
    }
}