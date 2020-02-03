using BerlinClock.App.Converters;
using BerlinClock.App.Parsers;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Constructor
{
    public class ClockConstructor
    {
        private readonly IClock _clock;
        public ClockConstructor(SupportedClocksEnum clockType)
        {
            switch (clockType)
            {
                case SupportedClocksEnum.Berlin:
                    _clock = new Clocks.BerlinClock(new WeirdString2TimeParser(), new SecondsConverter(), new MinutesConverter(), new HoursConverter());
                    break;
            }
        }

        public string ConvertTime(string timeStr)
        {
            return _clock.ConvertTime(timeStr);
        }
    }
}
