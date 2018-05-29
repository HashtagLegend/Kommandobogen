using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
    [Serializable]
    public class ActivityDate
    {
        public static int id { get; set; }
        public int ID { get; set; }
        public string ActivityID { get; set; }
        public string DatesTimeOffset { get; set; }

        public ActivityDate(string activityId, string date)
        {
            ActivityID = activityId;
            DatesTimeOffset = date;
            ID = new int();
        }

        public override string ToString()
        {
            return $"{nameof(ActivityID)}: {ActivityID}, {nameof(DatesTimeOffset)}: {DatesTimeOffset}";
        }
    }
}
