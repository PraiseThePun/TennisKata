namespace TennisKata
{
    public class Score
    {
        public int Points { get; set; }

        public int Games { get; set; }

        public int Sets { get; set; }

        public Score()
        {
            Points = 0;
            Games = 0;
            Sets = 0;
        }
    }
}
