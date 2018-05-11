using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KommandoBogApp.Singleton;

namespace KommandoBogApp.Model
{
    public class ActivityType
    {
        public string ActivityTypeName { get; set; }
        
        public ActivityType(string activityTypeName)
        {
            ActivityTypeName = activityTypeName;

        }

        public override string ToString()
        {
            return $"{ActivityTypeName}";
        }
    }
    
}
