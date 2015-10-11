

namespace Minesweeper.Logic
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Minesweeper.Core;

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
