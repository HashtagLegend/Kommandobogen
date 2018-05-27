using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{

    class ActivityDate
    {
        public static string Id { get; set; }
        public string ActivityID { get; set; }
        public string DatesTimeOffset { get; set; }

        public ActivityDate(string activityId, string date)
        {
            ActivityID = activityId;
            DatesTimeOffset = date.ToString();
            var id = int.Parse(Id);
            id++;
            Id = id.ToString();
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ActivityID)}: {ActivityID}, {nameof(DatesTimeOffset)}: {DatesTimeOffset}";
        }
    }
}
