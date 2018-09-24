using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USHolidays.Utils;

namespace USHolidays
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Holiday> holidays = new List<Holiday>();
            int year = 2022;

            foreach(string holidayName in ConfigurationManager.AppSettings.Keys)
            {
                HolidayRequest request = JsonConvert.DeserializeObject<HolidayRequest>(ConfigurationManager.AppSettings[holidayName].ToString());
                holidays.Add(Utils.Utils.GetHoliday(request,year));
            }

            foreach(var holiday in holidays)
            {
                Console.WriteLine(string.Format("{0} : {1}", holiday.Name, holiday.Date.ToShortDateString()));
            }

            Console.ReadLine();
        }
    
    }

}
