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
            Assert.AreEqual(0, player.Score.Points);

            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Points);
        }

        [Test]
        public void AddGameAddsOneGameTest()
        {
            Assert.AreEqual(0, player.Score.Games);

            player.ScoreGame();

            Assert.AreEqual(1, player.Score.Games);
        }

        [Test]
        public void AddSetAddsOneSetTest()
        {
            Assert.AreEqual(0, player.Score.Sets);

            player.ScoreSet();

            Assert.AreEqual(1, player.Score.Sets);
        }

        [Test]
        public void ResetGamesResetsPointsAndGamesTest()
        {
            player.ScoreGame();
            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Games);
            Assert.AreEqual(1, player.Score.Points);

            player.ResetGames();

            Assert.AreEqual(0, player.Score.Games);
            Assert.AreEqual(0, player.Score.Points);
        }

        [Test]
        public void ResetPointsResetsPointsTest()
        {
            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Points);

            player.ResetPoints();

            Assert.AreEqual(0, player.Score.Points);
        }

        [Test]
        public void ResetAllResetsAll()
        {
            player.ScoreSet();
            player.ScoreGame();
            player.ScorePoint();

            Assert.AreEqual(1, player.Score.Points);
            Assert.AreEqual(1, player.Score.Games);
            Assert.AreEqual(1, player.Score.Sets);

            player.ResetAll();

            Assert.AreEqual(0, player.Score.Points);
            Assert.AreEqual(0, player.Score.Games);
            Assert.AreEqual(0, player.Score.Sets);
        }
    }
}