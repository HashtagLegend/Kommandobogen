using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace KommandoBogApp.Model
{
    public class Activity
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        public Color Color { get; set; }

        public Activity(DateTime dateFrom, DateTime dateTo, string kommentar, string navn, Color color)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
        }

        public override string ToString()
        {
            return $"{nameof(DateFrom)}: {DateFrom}, {nameof(DateTo)}: {DateTo}, {nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        }
    }
}
