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

        public Vagt(List<DateTime> dates, string kommentar, string navn, Color color) : base(dates, kommentar, navn, color)
        {
            navn = "Vagt";
            color = Colors.Blue;
        }
    }
}
