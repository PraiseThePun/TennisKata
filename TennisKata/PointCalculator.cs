namespace TennisKata
{
    public class PointCalculator
    {
        private readonly int maxNumOfSets;
        private readonly int gamesToWinSet = 6;

        public PointCalculator(int maxNumOfSets)
        {
            this.maxNumOfSets = maxNumOfSets;
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
                result += "\nPlayer " + playerThatWon.Name + " wins the match!";

            if(CheckIfItsDeuce(playerThatWon.Score, playerThatLost.Score))
                result += "Deuce!";

            if (CheckIfItsAdvantadge(playerThatWon.Score, playerThatLost.Score))
                result += "Advantage for player " + playerThatWon.Name;

            return result;
        }

        public string PlayerScores(Player playerThatWon, Player playerThatLost)
        {
            playerThatWon.ScorePoint();

            var result = PerformPlayerScoreActions(playerThatWon, playerThatLost);

            if (string.IsNullOrEmpty(result))
                result += "Player " + playerThatWon.Name + " scored. " + playerThatWon.Score.ToString() + " - " + playerThatLost.Score.ToString();

            return result;
        }

        private bool CheckGameIsOver(Score playerThatWon)
        {
            return playerThatWon.Sets == maxNumOfSets;
        }

        private static bool CheckPlayerWonGame(Score playerThatWon, Score playerThatLost)
        {
            var diff = playerThatWon.Points - playerThatLost.Points;

            return playerThatWon.Points > 3 && diff > 1;
        }

        private bool CheckPlayerWonSet(Score playerThatWon)
        {
            return playerThatWon.Games == gamesToWinSet;
        }

        private static bool CheckIfItsAdvantadge(Score playerThatWon, Score playerThatLost)
        {
            return playerThatWon.Points >= 3 && playerThatLost.Points >= 3 && playerThatWon.Points != playerThatLost.Points;
        }

        private static bool CheckIfItsDeuce(Score playerThatWon, Score playerThatLost)
        {
            return playerThatWon.Points >= 3 && playerThatLost.Points >= 3 && playerThatWon.Points == playerThatLost.Points;
        }
    }
}
