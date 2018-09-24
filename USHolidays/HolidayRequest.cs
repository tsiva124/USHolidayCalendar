using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USHolidays
{
    public class HolidayRequest
    {
        public string HolidayName { get; set; }

        public HolidayType HolidayType { get; set; }

        public int Month { get; set; }

        public int DayOfMonth { get; set; }

        public int WeekOfMonth { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string Description { get; set; }
    }
}
