using NUnit.Framework;
using TennisKata;

namespace TennisKataTest
{
    public class ScoreTest
    {
        private Score score;

        [SetUp]
        public void Setup()
        {
            score = new Score();
        }

        [Test]
        public void ToStringReturnsZeroWhenPointsIsZero()
        {
            var result = score.PointsToString();

            Assert.AreEqual("zero", result);
        }

        [Test]
        public void ToStringReturnsFifteenWhenPointsIsOne()
        {
            score.Points = 1;
            var result = score.PointsToString();

            Assert.AreEqual("fifteen", result);
        }

        [Test]
        public void ToStringReturnsThirtyWhenPointsIsTwo()
        {
            score.Points = 2;
            var result = score.PointsToString();

            Assert.AreEqual("thirty", result);
        }

        [Test]
        public void ToStringReturnsFourtyWhenPointsIsThree()
        {
            score.Points = 3;
            var result = score.PointsToString();

            Assert.AreEqual("fourty", result);
        }
    }
}
