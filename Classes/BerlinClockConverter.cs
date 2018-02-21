using System;

namespace BerlinClock
{
    public class BerlinClockConverter : ITimeConverter
    {
        public string Convert(TimeSpan time)
        {
            if (time < TimeSpan.Zero || time > TimeSpan.FromDays(1))
            {
                throw new ArgumentOutOfRangeException(nameof(time));
            }

            var yellowLightState = GetYellowLightsState(time.Seconds);
            var hoursRows = GetLightsForHours(time.Days * 24 + time.Hours);
            var minutesRows = GetLightsForMinutes(time.Minutes);

            return string.Join(Environment.NewLine, yellowLightState, hoursRows, minutesRows);
        }

        private string GetYellowLightsState(int seconds)
        {
            return seconds % 2 == 0 ? "Y" : "O";
        }

        private string GetLightsForHours(int hours)
        {
            var firstRow = new string('R', hours / 5)
                .PadRight(4, 'O');
            var secondRow = new string('R', hours % 5)
                .PadRight(4, 'O');
            return string.Join(Environment.NewLine, firstRow, secondRow);
        }

        private string GetLightsForMinutes(int minutes)
        {
            var firstRow = new string('Y', minutes / 5)
                .PadRight(11, 'O')
                .Replace("YYY", "YYR");
            var secondRow = new string('Y', minutes % 5)
                .PadRight(4, 'O');
            return string.Join(Environment.NewLine, firstRow, secondRow);
        }
    }
}