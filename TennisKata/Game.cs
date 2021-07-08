namespace TennisKata
{
    public class Game
    {
        private readonly int maxNumOfSets;
        private const int GAMES_TO_WIN_SET = 6;
        private const int POINTS_TO_WIN_GAME = 3;
        private const int POINT_LIMIT = 10000;
        private int pointsCounter;

        public Game(int setsToWin)
        {
            this.maxNumOfSets = setsToWin;
            this.pointsCounter = 0;
        }

        private string PerformPlayerScoreActions(Player playerThatWon, Player playerThatLost)
        {
            var result = string.Empty;

            if (CheckPlayerWonGame(playerThatWon.Score, playerThatLost.Score))
            {
                playerThatWon.ScoreGame();
                playerThatLost.ResetPoints();

                result += "Game! " + playerThatWon.Score.Games + " - " + playerThatLost.Score.Games + " for player " + playerThatWon.Name;
            }

            if (CheckPlayerWonSet(playerThatWon.Score))
            {
                playerThatWon.ScoreSet();
                playerThatLost.ResetGames();

                result += "\nSet! " + playerThatWon.Score.Sets + " - " + playerThatLost.Score.Sets + " for player " + playerThatWon.Name;
            }

            if (CheckGameIsOver(playerThatWon.Score))
            {
                result += "\nPlayer " + playerThatWon.Name + " wins the match!";

                playerThatWon.ResetAll();
                playerThatLost.ResetAll();
            }

            if(CheckIfDeuce(playerThatWon.Score, playerThatLost.Score))
                result += "Deuce!";

            if (CheckIfIAdvantage(playerThatWon.Score, playerThatLost.Score))
                result += "Advantage for player " + playerThatWon.Name;

            return result;
        }

        public string PlayerScores(Player playerThatWon, Player playerThatLost)
        {
            playerThatWon.ScorePoint();
            pointsCounter++;

            if(pointsCounter >= POINT_LIMIT)
            {
                var winner = CheckWinnerPointsExceeded(playerThatWon, playerThatLost);
                return "\nThe point limit has been exceeded. Player " + winner.Name + " wins the match!";
            }

            var result = PerformPlayerScoreActions(playerThatWon, playerThatLost);

            if (string.IsNullOrEmpty(result))
                result += "Player " + playerThatWon.Name + " scored. " + playerThatWon.Score.PointsToString() + " - " + playerThatLost.Score.PointsToString();

            return result;
        }

        private Player CheckWinnerPointsExceeded(Player playerA, Player playerB)
        {
            if(playerA.Score.Sets == playerB.Score.Sets)
            {
                if (playerA.Score.Games == playerB.Score.Games)
                {
                    return playerA.Score.Points > playerB.Score.Points ? playerA : playerB;
                }
                else
                {
                    return playerA.Score.Games > playerB.Score.Games ? playerA : playerB;
                }
            }
            else
            {
                return playerA.Score.Sets > playerB.Score.Sets ? playerA : playerB;
            }
        }

        private bool CheckGameIsOver(Score playerThatWon)
        {
            return playerThatWon.Sets == maxNumOfSets;
        }

        private static bool CheckPlayerWonGame(Score playerThatWon, Score playerThatLost)
        {
            var diff = playerThatWon.Points - playerThatLost.Points;

            return playerThatWon.Points > POINTS_TO_WIN_GAME && diff > 1;
        }

        private static bool CheckPlayerWonSet(Score playerThatWon)
        {
            return playerThatWon.Games == GAMES_TO_WIN_SET;
        }

        private static bool CheckIfIAdvantage(Score playerThatWon, Score playerThatLost)
        {
            return playerThatWon.Points >= POINTS_TO_WIN_GAME && playerThatLost.Points >= POINTS_TO_WIN_GAME && playerThatWon.Points != playerThatLost.Points;
        }

        private static bool CheckIfDeuce(Score playerThatWon, Score playerThatLost)
        {
            return playerThatWon.Points >= POINTS_TO_WIN_GAME && playerThatLost.Points >= POINTS_TO_WIN_GAME && playerThatWon.Points == playerThatLost.Points;
        }
    }
}
