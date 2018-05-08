using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;

namespace KommandoBogApp.Model
{
    class Ferie : Activity
    {
        
        public Ferie(List<DateTimeOffset> dates, string kommentar, string navn, ActivityHandler.Color color) : base(dates, kommentar, navn, color)
        {
            navn = "Ferie";
            color = ActivityHandler.Color.Orange;
        }
    }
}
