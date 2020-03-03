using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class DateModifier
{
    public double GetDateDifference(string date1, string date2)
    {
        DateTime firstDate = DateTime.ParseExact(date1,"yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((firstDate - secondDate).TotalDays);
    }
}


