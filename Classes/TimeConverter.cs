using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private static readonly Regex TimeRegex = new Regex("^([0-9]{2}):([0-9]{2}):([0-9]{2})$", RegexOptions.Compiled);

        public string convertTime(string aTime)
        {
            var result = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(aTime))
                {
                    Console.WriteLine("You did not provide any time.");
                }

                var matchRegex = TimeRegex.Match(aTime);
                if (!matchRegex.Success)
                {
                    Console.WriteLine("Time format did not match.");
                }

                var hours = int.Parse(matchRegex.Groups[1].Value);
                var minutes = int.Parse(matchRegex.Groups[2].Value);
                var seconds = int.Parse(matchRegex.Groups[3].Value);
                if (hours < 0 || hours > 24)
                {
                    Console.WriteLine("Hours should be between 0 and 24");
                }
                else if (minutes < 0 || minutes > 59)
                {
                    Console.WriteLine("Minutes should be between 0 and 59");
                }
                else if (seconds < 0 || seconds > 59)
                {
                    Console.WriteLine("Seconds should be between 0 and 59");
                }
                else if (hours == 24 && (minutes > 0 || seconds > 0))
                {
                    Console.WriteLine("Time should be between 0 and 24.");
                }
                result = GetClockTime(hours, minutes, seconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public string GetClockTime(int hours, int minutes, int seconds)
        {
            var result = new StringBuilder();
            result.AppendLine((seconds % 2 == 0) ? "Y" : "O"); // Seconds first row
            result.AppendLine(CreateLightRow((hours / 5), "RRRR")); // Hours first row
            result.AppendLine(CreateLightRow((hours % 5), "RRRR")); // Hours second row
            result.AppendLine(CreateLightRow((minutes / 5), "YYRYYRYYRYY")); // Minutes first row
            result.Append(CreateLightRow((minutes % 5), "YYYY")); // Minutes second row
            return result.ToString();
        }

        private static string CreateLightRow(int noOfLightsOn, string rowWithAllLightsOn)
        {
            return rowWithAllLightsOn.Substring(0, noOfLightsOn) + new string('O', rowWithAllLightsOn.Length - noOfLightsOn);
        }
    }
}
