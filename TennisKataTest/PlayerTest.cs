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
            player = new Player("A");
        }

        [Test]
        public void AddPointAddsOnePointTest()
        {
            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Points);
        }

        [Test]
        public void AddGameAddsOneGameTest()
        {
            player.ScoreGame();

            Assert.AreEqual(1, player.Score.Games);
        }

        [Test]
        public void AddSetAddsOneSetTest()
        {
            player.ScoreSet();

            Assert.AreEqual(1, player.Score.Sets);
        }

        [Test]
        public void ResetGamesResetsPointsAndGamesTest()
        {
            player.ResetGames();

            Assert.AreEqual(0, player.Score.Games);
            Assert.AreEqual(0, player.Score.Points);
        }

        [Test]
        public void ResetPointsResetsPointsTest()
        {
            player.ResetPoints();

            Assert.AreEqual(0, player.Score.Points);
        }
    }
}