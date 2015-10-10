namespace Minesweeper.Logic
{
    using System;

    public static class Startup
    {
        public static void Main(string[] args)
        {
            Game minesweeper = Game.Instance();
            minesweeper.StartNewGame();
        }
    }
}
