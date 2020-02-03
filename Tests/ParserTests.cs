using System;
using BerlinClock.App.Parsers;
using NUnit.Framework;

namespace BerlinClock.Tests
{
    [TestFixture]
    public class ParserTests
    {
        #region set up

        private ITimeParser _weirdTimeParser;
        private ITimeParser _timeParser;

        [SetUp]
        public void SetUp()
        {
            _weirdTimeParser = new WeirdString2TimeParser();
            _timeParser = new String2TimeParser();
        }

        #endregion

        #region weird time parser

        [Test]
        [TestCase("10:10:10", 10, 10, 10)]
        [TestCase("00:00:00", 0, 0, 0)]
        [TestCase("24:00:00", 24, 0, 0)]
        [TestCase("0:0:0", 0, 0, 0)]
        [TestCase("23:59:59", 23, 59, 59)]
        public void PassingValidTimeStringToWeirdParser(string time, int hours, int minutes, int seconds)
        {
            var parsed = _weirdTimeParser.Parse(time);
            Assert.Multiple(() =>
            {
                Assert.That(parsed.Hours, Is.EqualTo(hours));
                Assert.That(parsed.Minutes, Is.EqualTo(minutes));
                Assert.That(parsed.Seconds, Is.EqualTo(seconds));
            });
        }

        [Test]
        [TestCase("1")]
        [TestCase("aaa")]
        [TestCase("1:22")]
        [TestCase("1:60:12")]
        [TestCase("25:60:12")]
        [TestCase("1:22:99")]
        [TestCase("1:22:-9")]
        public void PassingInvalidTimeStringToWeirdParser(string time)
        {
            Assert.Throws<ArgumentException>(() => _weirdTimeParser.Parse(time));
        }

        #endregion

        #region normal time parser

        [Test]
        [TestCase("10:10:10", 10, 10, 10)]
        [TestCase("00:00:00", 0, 0, 0)]
        [TestCase("0:0:0", 0, 0, 0)]
        [TestCase("23:59:59", 23, 59, 59)]
        public void PassingValidTimeStringToNormalParser(string time, int hours, int minutes, int seconds)
        {
            var parsed = _timeParser.Parse(time);
            Assert.Multiple(() =>
            {
                Assert.That(parsed.Hours, Is.EqualTo(hours));
                Assert.That(parsed.Minutes, Is.EqualTo(minutes));
                Assert.That(parsed.Seconds, Is.EqualTo(seconds));
            });
        }

        [Test]
        [TestCase("1")]
        [TestCase("aaa")]
        [TestCase("1:22")]
        [TestCase("1:22:99")]
        [TestCase("1:60:12")]
        [TestCase("25:60:12")]
        [TestCase("24:00:00")]
        [TestCase("1:22:-9")]
        public void PassingInvalidTimeStringToNormalParser(string time)
        {
            Assert.Throws<ArgumentException>(() => _timeParser.Parse(time));
        }

        #endregion
    }
}
