using Moq;
using NUnit.Framework;
using System;

namespace P10_TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class TirePressureMonitoringSystemTests
    {
        private IMock<Alarm> alarm;

        [SetUp]
        public void TestInit()
        {
            this.alarm = new Mock<Alarm>();
        }

        [Test]
        public void TestThatPressureWorks()
        {
            this.alarm.Object.
        }
    }
}
