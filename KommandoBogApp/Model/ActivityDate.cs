using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
    class ActivityDate
    {
        public static int Id = 0;
        public int ActivityID { get; set; }
        public DateTimeOffset DatesTimeOffset { get; set; }

        public ActivityDate(int activityId, DateTimeOffset date)
        {
            ActivityID = activityId;
            DatesTimeOffset = date;
            Id++;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(ActivityID)}: {ActivityID}, {nameof(DatesTimeOffset)}: {DatesTimeOffset}";
        }
    }
}
