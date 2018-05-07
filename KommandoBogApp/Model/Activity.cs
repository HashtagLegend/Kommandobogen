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
        
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        public Color Color { get; set; }
        public List<DateTime> Dates { get; set; }
        public bool IsConfirmed { get; set; }

        public Activity(List<DateTime> dates, string kommentar, string navn, Color color)
        {
            
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
            Dates = dates;
            IsConfirmed = false;
        }

        public override string ToString()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        }
    }
}
