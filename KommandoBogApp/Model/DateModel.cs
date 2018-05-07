using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KommandoBogApp.Model
{
    class DateModel
    {
        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public DateModel(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
