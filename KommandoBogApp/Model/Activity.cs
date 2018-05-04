using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace KommandoBogApp.Model
{
    public abstract class Activity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        public Color Color { get; set; }

        protected Activity(DateTime dateFrom, DateTime dateTo, string kommentar, string navn, Color color)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
        }

    }
}
