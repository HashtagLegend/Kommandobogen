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
        

        public Kursus(DateTime dateFrom, DateTime dateTo, string kommentar, string navn, Color color) : base(dateFrom, dateTo, kommentar, navn, color)
        {
            navn = "Kursus";
            color = Colors.DarkGreen;
        }
    }
}
