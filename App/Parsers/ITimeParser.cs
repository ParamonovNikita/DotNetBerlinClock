using BerlinClock.App.Models;

namespace BerlinClock.App.Parsers
{
    public interface ITimeParser
    {
        Time Parse(string str);
    }
}
