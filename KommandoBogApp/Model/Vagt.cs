using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;

namespace KommandoBogApp.Model
{
    class Vagt : Activity
    {

        public Vagt(List<DateTimeOffset> dates, string kommentar, string navn, ActivityHandler.Color color) : base(dates, kommentar, navn, color)
        {
            navn = "Vagt";
            color = ActivityHandler.Color.Blue;
        }
    }
}
