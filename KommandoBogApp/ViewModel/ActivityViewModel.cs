using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.ViewModel
{
    class ActivityViewModel
    {
        public DateTime ViewDateFrom { get; set; }
        public DateTime ViewDateTo { get; set; }
        public string ViewKommentar { get; set; }
        public string ViewNavn { get; set; }
        public Color ViewColor { get; set; }
        public string ViewActivityType { get; set; }
        public ActivitySingleton ActivityList { get; set; }
        public ActivityHandler ActivityHandler { get; set; }

        public ActivityViewModel()
        {
            ActivityList = ActivitySingleton.Instance;
            ActivityHandler = new ActivityHandler(this);
        }
    }
}
