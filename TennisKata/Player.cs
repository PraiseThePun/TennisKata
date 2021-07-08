namespace TennisKata
{
    public class Player
    {
        public Score Score { get; }
        public string Name { get; }

        public Player(string name)
        {
            Score = new Score();
            Name = name;
        }

        public void ScorePoint()
        {
            Score.Points++;
        }

        public void ScoreGame()
        {
            Score.Games++;
            Score.Points = 0;
        }

        public void ScoreSet()
        {
            Score.Sets++;
            Score.Games = 0;
            Score.Points = 0;
        }

        public void ResetGames()
        {
            Score.Games = 0;
            Score.Points = 0;
        }

        public void ResetPoints()
        {
            Score.Points = 0;
        }

        public void ResetAll()
        {
            Score.Points = 0;
            Score.Games = 0;
            Score.Sets = 0;
        }
    }
}
