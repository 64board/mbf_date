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

        public MBFDate(bool businessDates)
            : this(businessDates, "yyyyMMdd")
        {
        }

        public MBFDate(bool businessDates, string dateFormat)
        {
            format = dateFormat;
            today = DateTime.Today;

            int subtractDays = -1;
            // On Mondays the previous date is Friday
            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                if (businessDates)
                {
                    subtractDays = -3;
                } else
                {
                    subtractDays = -1;
                }
            }
            previousDate = today.AddDays(subtractDays);

            int addDays = 1;
            // On Fridays the next date is Monday
            if (today.DayOfWeek == DayOfWeek.Friday)
            {
                if (businessDates)
                {
                    addDays = 3;
                }
                else
                {
                    addDays = 1;
                }
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