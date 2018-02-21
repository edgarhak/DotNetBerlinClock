using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new BerlinClockConverter();
        private TimeSpan time;

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string timeToConvert)
        {
            time = timeToConvert == "24:00:00" ? TimeSpan.FromDays(1) : TimeSpan.Parse(timeToConvert);
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.Convert(time), theExpectedBerlinClockOutput);
        }
    }
}
