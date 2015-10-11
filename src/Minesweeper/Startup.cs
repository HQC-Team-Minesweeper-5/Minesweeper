//-----------------------------------------------------------------------
// <copyright file="Startup.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class starts the minesweeper game.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper
{
    using System;
    using Minesweeper.Core;

    /// <summary>
    /// Class which is the entry point of the game.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Entry point of the game.
        /// </summary>
        public static void Main()
        {
            Game minesweeper = Game.Instance();
            minesweeper.StartNewGame();

            Console.Read();
        }
    }
}
