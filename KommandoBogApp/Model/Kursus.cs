using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace KommandoBogApp.Model
{
    class Kursus : Activity
    {
        

        public Kursus(List<DateTimeOffset> dates, string kommentar, string navn, Color color, int hour, int minutes) : base(dates, kommentar, navn, color, hour, minutes)
        {
            navn = "Kursus";
            color = Colors.DarkGreen;
        }
    }
}
