using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    using System;
    using System.Threading;

    public static class Startup
    {
        public static void Main(string[] args)
        {
            Game minesweeper = Game.Instance();
            minesweeper.StartNewGame();

            Console.Read();
        }
    }
}
