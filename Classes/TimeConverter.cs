using BerlinClock.App.Constructor;
using BerlinClock.App.Shared;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var clockConverter = new ClockConstructor(SupportedClocksEnum.Berlin);
            return clockConverter.ConvertTime(aTime);
        }
    }
}
