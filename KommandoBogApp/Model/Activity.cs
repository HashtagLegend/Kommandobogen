using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Search;
using Windows.UI;

namespace KommandoBogApp.Model
{
    public abstract class Activity
    {
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        public Color Color { get; set; }
        public List<DateTime> Dates { get; set; }

        protected Activity(List<DateTime> dates, string kommentar, string navn, Color color)
        {
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
            dates = Dates;
        }

    }
}
