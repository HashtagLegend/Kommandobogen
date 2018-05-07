using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace KommandoBogApp.Model
{
    class Fri : Activity
    {

        public Fri(List<DateTime> dates, string kommentar, string navn, Color color) : base(dates, kommentar, navn, color)
        {
            navn = "fri";
            color = Colors.Firebrick;
        }
    }
}
