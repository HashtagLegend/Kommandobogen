using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using KommandoBogApp.Handler;
using KommandoBogApp.Persistency;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.Model
{
    [Serializable]
    public class Activity
    {
        //Non Serializeable kommer ikke med som properties i DB
        public string Kommentar { get; set; }
        public string Navn { get; set; }
        [NonSerialized] public ActivityHandler.Color color;
        public string Color { get; set; }
        public Color _color { get; set; }
        [NonSerialized] public List<DateTimeOffset> Dates;
        [NonSerialized] public static int id = 0;
        public string MaNummer { get; set; }
        public string ID { get; set; }
        [NonSerialized] public int Hour;
        public string DatesFromAndTo { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public List<int> DatesID { get; set; }
     
        public ActivityType ActivityTypeName { get; set; }

        public Activity(List<DateTimeOffset> dates, string kommentar, string navn, ActivityHandler.Color _color)
        {           
            Kommentar = kommentar;
            Navn = navn;
            color = _color;
            Dates = dates;
            ID = id.ToString();
            id++;
            ColorString();
            Color = color.ToString();
            DatesID = new List<int>();
        }
        // Farven til aktiviter gives
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
        //Slet aktivity 
        public async void SelfDestruct()
        {
            await Task.Run(async () =>
            {
                foreach (var date in DatesID)
                {
                     DatesPersistency.DeleteDateAsync(date);
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                ActivityPersistency.DeleteActivityAsync(this);
                UserCatalogSingleton.Instance.LoginUser.Activities.Remove(this);
            });
        }
        //Liste initialiseres
        public void Initializelist()
        {
            Dates = new List<DateTimeOffset>();
        }

        #region ToStrings

        public void ToStringDate()
        {
            if (Dates != null)
            {
                if (Dates.Count >= 1)
                {
                    DateTimeOffset HighestDate = Dates.First();
                DateTimeOffset LowestDate = Dates.First();
                if (Dates.Count == 1)
                {
                    var NewTimeEnd = TimeSpan.Parse(TimeEnd);
                    var NewTimeStart = TimeSpan.Parse(TimeStart);
                    HighestDate = new DateTimeOffset(DateTime.SpecifyKind(
                        new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, NewTimeEnd.Hours, NewTimeEnd.Minutes,
                            NewTimeEnd.Seconds), DateTimeKind.Utc));
                    LowestDate = new DateTimeOffset(DateTime.SpecifyKind(
                        new DateTime(Dates[0].Year, Dates[0].Month, Dates[0].Day, NewTimeStart.Hours,
                            NewTimeStart.Minutes, NewTimeStart.Seconds), DateTimeKind.Utc));
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
                DatesFromAndTo =
                    $"{LowestDate.Day} - {LowestDate.Month} - {LowestDate.Year} kl {LowestDate.TimeOfDay} Til {HighestDate.Day} - {HighestDate.Month} - {HighestDate.Year} kl {HighestDate.TimeOfDay}";
                }
                
            }
        }

       

        //public override string ToString()
        //{
        //    return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}";
        //}

        public override string ToString()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}, {nameof(MaNummer)}: {MaNummer}, {nameof(ID)}: {ID}, {nameof(TimeStart)}: {TimeStart}, {nameof(TimeEnd)}: {TimeEnd}";
        }

        public string ToStringDatabase()
        {
            return $"{nameof(Kommentar)}: {Kommentar}, {nameof(Navn)}: {Navn}, {nameof(Color)}: {Color}, {nameof(MaNummer)}: {MaNummer}, {nameof(TimeStart)}: {TimeStart}, {nameof(TimeEnd)}: {TimeEnd}, {nameof(ID)}: {ID}";
        }

        #endregion
    }
}
