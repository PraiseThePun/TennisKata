using NUnit.Framework;
using TennisKata;

namespace TennisKataTest
{
    public class PlayerTest
    {
        private Player player;

        [SetUp]
        public void Setup()
        {
            player = new Player();
        }

        [Test]
        public void AddPointTest()
        {
            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Points);
        }

        [Test]
        public void AddGameTest()
        {
            player.ScoreGame();

            Assert.AreEqual(1, player.Score.Games);
        }

        [Test]
        public void AddSetTest()
        {
            player.ScoreSet();

            Assert.AreEqual(1, player.Score.Sets);
        }
    }
}