namespace Minesweeper.Logic
{
    using Logic;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Game minesweeper = new Game();
            minesweeper.StartNewGame();
        }
    }
}
