using System;
using BerlinClock.App.Models;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Parsers
{
    public class String2TimeParser : ITimeParser
    {
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

            throw new ArgumentException("Provided string \"" + str + "\" has incorrect format, expected format - HH:mm:ss");
        }

        private bool IsValidStringFormat(string str)
        {
            return str.Split(':').Length - 1 == Constants.AllowedColonsAmount;
        }
    }
}
