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
        public ActivityHandler.Color color { get; set; }
        public string Color { get; set; }
        public Color _color { get; set; }
        public List<DateTimeOffset> Dates { get; set; }
        public static int ID { get; set; }
        public string MaNummer { get; set; }
        public int id { get; set; }
        public int Hour { get; set; }
        public string DatesFromAndTo { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
     
        public ActivityType ActivityTypeName { get; set; }

        public Activity(List<DateTimeOffset> dates, string kommentar, string navn, ActivityHandler.Color _color)
        {           
            Kommentar = kommentar;
            Navn = navn;
            color = _color;
            Dates = dates;
            id = ID;
            ID++;
            ColorString();
        }

        public string ColorString()
        {
            if (color == ActivityHandler.Color.DarkGreen)
                _color = Windows.UI.Color.FromArgb(255,0,100,0);

            if (color == ActivityHandler.Color.Blue)
                _color = Windows.UI.Color.FromArgb(255, 0, 0, 100);

            if (color == ActivityHandler.Color.Firebrick)
                _color = Windows.UI.Color.FromArgb(255, 178, 38, 38);

            if (color == ActivityHandler.Color.Orange)
                _color = Windows.UI.Color.FromArgb(255, 255, 165, 0);
            return null;
        }

        public void Initializelist()
        {
            Dates = new List<DateTimeOffset>();
        }

        #region ToStrings

        public void ToStringDate()
        {
            DateTimeOffset HighestDate = Dates.First();
            DateTimeOffset LowestDate = Dates.First();
            if (Dates.Count == 1)
            {

                HighestDate = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, TimeEnd.Hours, TimeEnd.Minutes, TimeEnd.Seconds), DateTimeKind.Utc));
                LowestDate = new DateTimeOffset(DateTime.SpecifyKind(new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, TimeStart.Hours, TimeStart.Minutes, TimeStart.Seconds), DateTimeKind.Utc));
            }
            if (Dates.Count >= 2)
            {
                foreach (var VARIABLE in Dates)
                {
                    if (VARIABLE >= HighestDate)
                    {
                        HighestDate = VARIABLE;
                    }
                    if (VARIABLE <= LowestDate)
                    {
                        LowestDate = VARIABLE;
                    }
                }
            }
            DatesFromAndTo = $"{LowestDate.Day} - {LowestDate.Month} - {LowestDate.Year} kl {LowestDate.TimeOfDay} Til {HighestDate.Day} - {HighestDate.Month} - {HighestDate.Year} kl {HighestDate.TimeOfDay}";
        }

       

        public override string ToString()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        }

        #endregion
    }
}
