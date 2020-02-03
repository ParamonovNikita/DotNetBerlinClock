using System;
using BerlinClock.App.Models;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Parsers
{
    /// <summary>
    /// This is "weird" time parser because I believe that "24:00:00" is an incorrect time format.
    /// At least how it possible to have "00:00:00" and "24:00:00"?
    /// For tests from BDD folder sake I use this parser in application.
    /// </summary>
    public class WeirdString2TimeParser : ITimeParser
    {
        private const string SpecialCase = "24:00:00";

        public Time Parse(string str)
        {
            if (IsValidStringFormat(str))
            {
                if (DateTime.TryParse(str, out var time))
                {
                    return new Time
                    {
                        Hours = time.Hour,
                        Minutes = time.Minute,
                        Seconds = time.Second
                    };
                }
            }

            if (str.Equals(SpecialCase))
            {
                return new Time
                {
                    Hours = 24,
                    Minutes = 0,
                    Seconds = 0
                };
            }

            throw new ArgumentException("Provided string \"" + str + "\" has incorrect format, expected format - HH:mm:ss");
        }

        private bool IsValidStringFormat(string str)
        {
            return str.Split(':').Length - 1 == Constants.AllowedColonsAmount;
        }
    }
}
