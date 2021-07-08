using NUnit.Framework;
using TennisKata;

namespace TennisKataTest
{
    public class GameTest
    {
        private Player playerA;
        private Player playerB;
        private Game game;
        private const int MAX_SETS = 2;

        [SetUp]
        public void Setup()
        {
            playerA = new Player("A");
            playerB = new Player("B");
            game = new Game(MAX_SETS);
        }

        [Test]
        public void PlayerAScoresFifteenZero()
        {
            var result = game.PlayerScores(playerA, playerB);

            Assert.AreEqual("Player A scored. fifteen - zero", result);
        }

        [Test]
        public void PlayerAWinsAGame()
        {
            var result = "";

            for (int i = 0; i < 4; i++)
            {
                result = game.PlayerScores(playerA, playerB);
            }

            Assert.AreEqual("Game! 1 - 0 for player A", result);
        }

        [Test]
        public void PlayerAWinsASet()
        {
            var result = "";

            for (int i = 0; i < 24; i++)
            {
                result = game.PlayerScores(playerA, playerB);
            }

            Assert.AreEqual("Game! 6 - 0 for player A\nSet! 1 - 0 for player A", result);
        }

        [Test]
        public void PlayerAWinTheMatch()
        {
            var result = "";

            for (int i = 0; i < 48; i++)
            {
                result = game.PlayerScores(playerA, playerB);
            }

            Assert.AreEqual("Game! 6 - 0 for player A\nSet! 2 - 0 for player A\nPlayer A wins the match!", result);
        }

        [Test]
        public void PlayersGetADeuce()
        {
            var result = "";

            for (int i = 0; i < 3; i++)
            {
                _ = game.PlayerScores(playerA, playerB);
                result = game.PlayerScores(playerB, playerA);
            }

            Assert.AreEqual("Deuce!", result);
        }

        [Test]
        public void PlayersAGetAdvantage()
        {
            for (int i = 0; i < 3; i++)
            {
                _ = game.PlayerScores(playerA, playerB);
                _ = game.PlayerScores(playerB, playerA);
            }

            var result = game.PlayerScores(playerA, playerB);

            Assert.AreEqual("Advantage for player A", result);
        }

        [Test]
        public void PlayerAWinsByLimitPointExceeded()
        {
            game = new Game(417);
            var result = "";

            for (int i = 0; i < 10001; i++)
            {
                result = game.PlayerScores(playerA, playerB);
            }

            Assert.AreEqual("\nThe point limit has been exceeded. Player A wins the match!", result);
        }
    }
}
