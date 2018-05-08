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
        public List<DateTimeOffset> Dates { get; set; }
        public bool IsConfirmed { get; set; }
        public static int ID { get; set; }
        public int id { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Activity(List<DateTimeOffset> dates, string kommentar, string navn, Color color, int hour, int minutes)
        {           
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
            Dates = dates;
            IsConfirmed = false;
            id = ID;
            ID++;
            Hour = hour;
            Minutes = minutes;
            Seconds = 0;
        }

        public override string ToString()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        }
    }
}
