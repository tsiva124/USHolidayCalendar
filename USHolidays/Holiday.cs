using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USHolidays
{
    public class Holiday
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int Year {
            get {
                return Date.Year;
            }
        }
    }
}
