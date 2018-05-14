using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;

namespace KommandoBogApp.Model
{
    public class Activity
    {
        
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        public ActivityHandler.Color Color { get; set; }
        public Color color { get; set; }
        public List<DateTimeOffset> Dates { get; set; }
        public static int ID { get; set; }
        public int id { get; set; }
        public int Hour { get; set; }
        public string DatesFromAndTo { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
     
        public ActivityType ActivityTypeName { get; set; }

        public Activity(List<DateTimeOffset> dates, string kommentar, string navn, ActivityHandler.Color color)
        {           
            Kommentar = kommentar;
            Navn = navn;
            Color = color;
            Dates = dates;
            id = ID;
            ID++;
            ColorString();
        }

        public string ColorString()
        {
            if (Color == ActivityHandler.Color.DarkGreen)
                color = Windows.UI.Color.FromArgb(255,0,100,0);

            if (Color == ActivityHandler.Color.Blue)
                color = Windows.UI.Color.FromArgb(255, 0, 0, 100);

            if (Color == ActivityHandler.Color.Firebrick)
                color = Windows.UI.Color.FromArgb(255, 178, 38, 38);

            if (Color == ActivityHandler.Color.Orange)
                color = Windows.UI.Color.FromArgb(255, 255, 165, 0);
            return null;
        }

        public void ToStringDate()
        {
            DateTimeOffset HighestDate = Dates.First();
            DateTimeOffset LowestDate = Dates.First();
            if (Dates.Count == 1)
            {
                Debug.WriteLine("TimeEnd og TimeStart" + TimeEnd + TimeStart);
                HighestDate = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, TimeEnd.Hours, TimeEnd.Minutes, TimeEnd.Seconds), DateTimeKind.Utc));
                Debug.WriteLine("Highest" + HighestDate.Date);
                LowestDate = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, TimeStart.Hours, TimeStart.Minutes, TimeStart.Seconds), DateTimeKind.Utc));
                Debug.WriteLine("Lowest"+ LowestDate.Date);
            }
            if (Dates.Count >= 2)
            {
                foreach (var VARIABLE in Dates)
                {
                    if (VARIABLE >= HighestDate)
                    {
                        HighestDate = VARIABLE;
                        Debug.WriteLine("Highest Variable" + VARIABLE.TimeOfDay);
                        Debug.WriteLine("Highest" + HighestDate.TimeOfDay);
                    }
                    if (VARIABLE <= LowestDate)
                    {
                        LowestDate = VARIABLE;
                        Debug.WriteLine("Lowest Variable" + VARIABLE.TimeOfDay);
                        Debug.WriteLine("Lowest" + LowestDate.TimeOfDay);
                    }
                }
            }
            DatesFromAndTo = $"{LowestDate.ToString("dd/mm/yyyy")} kl {LowestDate.TimeOfDay} Til {HighestDate.ToString("dd/mm/yyyy")} kl {HighestDate.TimeOfDay}";
        }

       

        public override string ToString()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        }
    }
}
