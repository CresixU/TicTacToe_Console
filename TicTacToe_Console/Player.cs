namespace TicTacToe_Console
{
    public class Player
    {
        public string Name { get; set; }
        public int TotalGames { get; set; }
        public int WinGames { get; set; }
        public int LoseGames { get; set; }
        public int DrawGames { get; set; }
        public int WinRatio
        {
            get
            {
                if (TotalGames != 0)
                    return WinGames / TotalGames * 100;
                return 0;
            }
        }

        public Player(string name)
        {
            Name = name;
            WinGames = 0;
            LoseGames = 0;
            DrawGames = 0;
        }

        public void Win()
        {
            TotalGames++;
            WinGames++;
        }

        public void Lose()
        {
            TotalGames++;
            LoseGames++;
        }

        public void Draw()
        {
            TotalGames++;
            DrawGames++;
        }

    }

}
