using System;
using System.Linq;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int DayCalculator(string date1, string date2)
        {
            int[] firstDate = date1
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondDate = date2
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DateTime first = new DateTime(firstDate[0], firstDate[1], firstDate[2]);
            DateTime second = new DateTime(secondDate[0], secondDate[1], secondDate[2]);

            return Math.Abs((first - second).Days); 
        }
    }
}
