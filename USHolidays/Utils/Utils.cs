using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USHolidays.Utils
{
    /// <summary>
    /// Utils extension class
    /// </summary>
    public static class Utils
    {

        public static Holiday GetHoliday(HolidayRequest request,int year)
        {

            Holiday holiday = new Holiday() { Name = request.HolidayName , Description = request.Description};

            switch(request.HolidayType)
            {
                case HolidayType.Fixed:
                        holiday.Date = (new DateTime(year, request.Month, request.DayOfMonth)).ClosestWeekDay();
                    break;

                case HolidayType.Floating:
                        for (int i = 0; i < 7; ++i)
                        {
                            DateTime floatingDate = new DateTime(year, request.Month, i + 1);
                            if (floatingDate.DayOfWeek == request.DayOfWeek)
                            {
                                floatingDate = floatingDate.AddDays(7*(request.WeekOfMonth - 1));
                                holiday.Date = floatingDate.ClosestWeekDay();
                                break;
                            }
                        }
                    break;

                case HolidayType.LastDayOfMonth:

                        DateTime date = new DateTime(year, request.Month, DateTime.DaysInMonth(year,request.Month));
                        while(date.DayOfWeek != request.DayOfWeek)
                        {
                            date = date.AddDays(-1);
                        }
                        holiday.Date = date.ClosestWeekDay();
                    break;
            }

            return holiday;
        }

        public static DateTime ClosestWeekDay(this DateTime weekend)
        {
            DayOfWeek dayOfWeek = weekend.DayOfWeek;

            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return weekend.AddDays(-1);

                case DayOfWeek.Sunday:
                    return weekend.AddDays(1);

                default:
                    return weekend;
            }
        }
    }
}
