using System;
using BerlinClock.App.Extensions;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Converters
{
    public class SecondsConverter : BaseConverter, IConvert
    {
        private const int MinLimit = 0;
        private const int MaxLimit = 60;

        private int _seconds;

        public string Convert(int seconds)
        {
            Validate(seconds);
            _seconds = seconds;
            return PrepareResponse();
        }

        protected override void Validate(int seconds)
        {
            if (seconds < MinLimit)
            {
                throw new ArgumentException("Seconds must be equal or greater then " + MinLimit);
            }

            if (seconds >= MaxLimit)
            {
                throw new ArgumentException("Seconds must be less then " + MaxLimit);
            }
        }

        protected override string PrepareResponse()
        {
            return _seconds % 2 == 1 ? ColorsEnum.Off.GetDescription() : ColorsEnum.Yellow.GetDescription();
        }
    }
}
