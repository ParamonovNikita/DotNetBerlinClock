using System;
using BerlinClock.App.Converters;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class ConversionTests
    {
        #region setup

        private IConvert _secondsConverter;
        private IConvert _hoursConverter;
        private IConvert _minutesConverter;

        [SetUp]
        public void SetUp()
        {
            _secondsConverter = new SecondsConverter();
            _hoursConverter = new HoursConverter();
            _minutesConverter = new MinutesConverter();
        }

        #endregion

        #region seconds conversion tests

        [Test]
        [TestCase(1, "O")]
        [TestCase(2, "Y")]
        [TestCase(0, "Y")]
        public void SecondsValidConversion(int value, string expectedColor)
        {
            Assert.That(_secondsConverter.Convert(value), Is.EqualTo(expectedColor));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(99)]
        public void SecondsInvalidConversion(int value)
        {
            Assert.Throws<ArgumentException>(() => _secondsConverter.Convert(value));
        }

        #endregion

        #region minutes conversion tests

        [Test]
        [TestCase(59, "YYRYYRYYRYY\r\nYYYY")]
        [TestCase(17, "YYROOOOOOOO\r\nYYOO")]
        [TestCase(0, "OOOOOOOOOOO\r\nOOOO")]
        public void MinutesValidConversion(int value, string expectedColor)
        {
            Assert.That(_minutesConverter.Convert(value), Is.EqualTo(expectedColor));
        }

        [Test]
        [TestCase(61)]
        [TestCase(-1)]
        public void MinutesInvalidConversion(int value)
        {
            Assert.Throws<ArgumentException>(() => _minutesConverter.Convert(value));
        }

        #endregion

        #region hours conversion tests

        [Test]
        [TestCase(23, "RRRR\r\nRRRO")]
        [TestCase(20, "RRRR\r\nOOOO")]
        [TestCase(13, "RROO\r\nRRRO")]
        [TestCase(0, "OOOO\r\nOOOO")]
        public void HoursValidConversion(int value, string expectedColor)
        {
            Assert.That(_hoursConverter.Convert(value), Is.EqualTo(expectedColor));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(25)]
        public void HoursInvalidConversion(int value)
        {
            Assert.Throws<ArgumentException>(() => _hoursConverter.Convert(value));
        }

        #endregion
    }
}
