namespace TennisKata
{
    public enum PointsEnum
    {
        Zero = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Deuce = 4,
        Ad_in = 5,
        Ad_out = 6
    }

    public class Player
    {
        public Score Score { get; private set; }

        public Player()
        {
            Score = new Score();
        }

        public void ScorePoint()
        {
            Score.Points++;
        }

        public void ScoreGame()
        {
            Score.Games++;
        }

        public void ScoreSet()
        {
            Score.Sets++;
        }
    }
}
