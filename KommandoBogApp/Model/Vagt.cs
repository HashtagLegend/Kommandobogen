using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace KommandoBogApp.Model
{
    class Vagt : Activity
    {
       
        public Vagt(DateTime dateFrom, DateTime dateTo, string kommentar, string navn, Color color, string activityType) : base(dateFrom, dateTo, kommentar, navn, color, activityType)
        {
            navn = "Vagt";
            color = Colors.Blue;
        }
        
    }
}
