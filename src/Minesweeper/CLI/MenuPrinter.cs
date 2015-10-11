//-----------------------------------------------------------------------
// <copyright file="MenuPrinter.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class prints the level selector in the beginning of the minesweeper game & the game menu during each game.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.CLI
{
    using System;
    using Minesweeper.Core;
    using Minesweeper.Utils;

    /// <summary>
    /// Prints the level selector and game menu.
    /// </summary>
    internal class MenuPrinter
    {
        /// <summary>
        /// The height of the console.
        /// </summary>
        private const int ConsoleHeight = 29;

        /// <summary>
        /// The width of the console.
        /// </summary>
        private const int ConsoleWidth = 80;

        /// <summary>
        /// Sets up the console for the game.
        /// </summary>
        public void ConsoleSetUp()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(ConsoleWidth, ConsoleHeight);
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Prints the game background.
        /// </summary>
        public void PrintBackground()
        {
            const int PadSize = 34;

            int numberOfMines = Game.Instance().NumberOfMines;
            int numberOfFlags = Game.Instance().NumberOfFlags;
            int gameScore = Game.Instance().GameBoard.OpenCellsCounter;

            string gameTitle = "Minesweeper";
            string score = string.Format("Score: {0}", gameScore);
            string mines = string.Format("Mines: {0}/{1}", numberOfMines - numberOfFlags, numberOfMines);

            Console.WriteLine(new string(' ', ConsoleWidth * ConsoleHeight));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.Write(score.PadRight(PadSize, ' '));
            Console.Write(gameTitle);
            Console.Write(mines.PadLeft(PadSize + 1, ' '));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Prints the level selector in the beginning of the game.
        /// </summary>
        /// <returns>The current game level.</returns>
        public Level GameLevelSelector()
        {
            string[] menuText = { "Level 1", "Level 2", "Level 3", " Exit" };
            int select = 0;
            this.PrintSelectionMenu(select, menuText, ConsoleWidth);

            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                // Move up selection
                if (userInput.Key == ConsoleKey.UpArrow && select >= 1)
                {
                    select--;
                }

                // Move down selection
                if (userInput.Key == ConsoleKey.DownArrow && select <= menuText.Length - 2)
                {
                    select++;
                }

                // Stop selection process
                if (userInput.Key == ConsoleKey.Enter)
                {
                    break;
                }

                this.PrintSelectionMenu(select, menuText, ConsoleWidth);
            }
            
            switch (select)
            {
                case 0:
                    return new Level(9, 9, 10);
                case 1:
                    return new Level(14, 14, 30);
                case 2:
                    return new Level(14, 20, 50);
                default:
                    Console.Clear();
                    Environment.Exit(0);
                    return new Level(0, 0, 0);
            }
        }

        /// <summary>
        /// Prints the level selection menu.
        /// </summary>
        /// <param name="selected">Current user choice.</param>
        /// <param name="menu">An array holding the menu items.</param>
        /// <param name="width">Width of the console.</param>
        public void PrintSelectionMenu(int selected, string[] menu, int width)
        {
            Console.Clear();
            var totalWidth = width;
            Console.CursorVisible = false;
            Console.WriteLine();
            for (int i = 0; i < menu.Length; i++)
            {
                // Take care of even lenght situation
                int n = menu[i].Length % 2 == 0 ? 1 : 0;

                // set color for the selected option
                if (i == selected) 
                {
                    // Set color
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine((">  " + menu[i]).PadLeft(((totalWidth - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                             .PadRight(totalWidth));  // centering text

                    // Reset color
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(menu[i].PadLeft(((totalWidth - menu[i].Length) / 2)
                                            + menu[i].Length - n)
                                            .PadRight(totalWidth));
                }
            }
        }
    }
}
