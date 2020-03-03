using Moq;
using NUnit.Framework;
using System;

namespace P09_DateTime.Tests
{
    [TestFixture]
    public class DateTimeTests
    {
        private Mock<IClock> time;

        [SetUp]
        public void TestInit()
        {
            time = new Mock<IClock>();
        }

        [Test]
        public void GetCurrentTime()
        {
            this.time.SetupGet(x => x.Now).Returns(DateTime.Now);

            Assert.That(DateTime.Now.ToShortTimeString(), Is.EqualTo(time.Object.Now.ToShortTimeString()));
        }

        [Test]
        public void AddDayInMiddleOfMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2015, 7, 15));

            DateTime testClock = this.time.Object.Now.AddDays(1);

            Assert.That(testClock.Day == 16);
        }

        [Test]
        public void AddDayThatChangesToNextMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 11, 30));

            DateTime testClock = this.time.Object.Now.AddDays(1);

            Assert.That(testClock.Month == 12 && testClock.Day == 1);
        }

        [Test]
        public void AddNegativeDays()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 05, 30));

            DateTime testClock = this.time.Object.Now.AddDays(-5);

            Assert.That(testClock.Month == 5 && testClock.Day == 25);
        }

        [Test]
        public void AddNegativeDaysThatChangesToPreviousMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 05, 31));

            DateTime testClock = this.time.Object.Now.AddDays(-31);

            Assert.That(testClock.Month == 4 && testClock.Day == 30);
        }

        [Test]
        public void AddDayToLeapYearMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2016, 02, 28));

            DateTime testClock = this.time.Object.Now.AddDays(1);

            Assert.That(testClock.Month == 2 && testClock.Day == 29);
        }

        [Test]
        public void AddDayToNonLeapYearMonth()
        {
            this.time.SetupProperty(x => x.Now, new DateTime(2017, 02, 28));

            DateTime testClock = this.time.Object.Now.AddDays(1);

            Assert.That(testClock.Month == 3 && testClock.Day == 1);
        }

        [Test]
        public void AddDayToDateTimeMaxVal()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

            Assert.That(() => this.time.Object.Now.AddDays(1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void AddDayToDateTimeMinVal()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MinValue);

            Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMinVal()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MinValue);

            Assert.That(() => this.time.Object.Now.AddDays(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void SubtractDayToDateTimeMaxVal()
        {
            this.time.SetupProperty(x => x.Now, DateTime.MaxValue);

            Assert.DoesNotThrow(() => this.time.Object.Now.AddDays(-1));
        }
    }
}
