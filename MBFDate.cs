using System;
using System.Collections.Generic;
using System.Text;

namespace mbf_date
{
    class MBFDate
    {
        private DateTime today;
        private DateTime previousDate;
        private DateTime nextDate;
        private string format;

        public MBFDate()
            : this("yyyyMMdd")
        {
        }

        public MBFDate(string dateFormat)
        {
            format = dateFormat;
            today = DateTime.Today;

            int subtractDays = -1;
            // On Mondays the previous date is Friday
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                subtractDays = -3;
            }
            previousDate = today.AddDays(subtractDays);

            int addDays = 1;
            // On Fridays the next date is Monday
            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                addDays = 3;
            }
            nextDate = today.AddDays(addDays);
        }

        public override String ToString()
        {
            return String.Format("CurrentDate={0} PreviousDate={1} NextDate={2}",
                today.ToString(format), previousDate.ToString(format),
                nextDate.ToString(format));
        }

        public String getCurrentDate()
        {
            return today.ToString(format);
        }

        public String getPreviousDate()
        {
            return previousDate.ToString(format);
        }

        public String getNextDate()
        {
            return nextDate.ToString(format);
        }
    }
}