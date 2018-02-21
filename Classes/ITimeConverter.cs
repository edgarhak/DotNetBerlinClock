using System;

namespace BerlinClock
{
    public interface ITimeConverter
    {
        string Convert(TimeSpan time);
    }
}
