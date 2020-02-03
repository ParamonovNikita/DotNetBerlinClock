using System.Text;
using BerlinClock.App.Converters;
using BerlinClock.App.Parsers;
using BerlinClock.App.Shared;

namespace BerlinClock.App.Clocks
{
    public class BerlinClock : IClock
    {
        private readonly ITimeParser _parser;
        private readonly IConvert _secondsConverter;
        private readonly IConvert _minutesConverter;
        private readonly IConvert _hoursConverter;

        public BerlinClock(ITimeParser parser, IConvert secondsConverter, IConvert minutesConverter, IConvert hoursConverter)
        {
            _parser = parser;
            _secondsConverter = secondsConverter;
            _minutesConverter = minutesConverter;
            _hoursConverter = hoursConverter;
        }

        public string ConvertTime(string timeStr)
        {
            var parsedTime = _parser.Parse(timeStr);
            var result = new StringBuilder();
            result.AppendLine(_secondsConverter.Convert(parsedTime.Seconds));
            result.AppendLine(_hoursConverter.Convert(parsedTime.Hours));
            result.Append(_minutesConverter.Convert(parsedTime.Minutes));
            return result.ToString();
        }
    }
}
