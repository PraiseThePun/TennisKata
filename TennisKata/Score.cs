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

        public override string ToString()
        {
            return Points switch
            {
                0 => "zero",
                1 => "fifteen",
                2 => "thirty",
                3 => "fourty",
                _ => string.Empty,
            };
        }
    }
}
