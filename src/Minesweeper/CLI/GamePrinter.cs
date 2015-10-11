//-----------------------------------------------------------------------
// <copyright file="GamePrinter.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class prints the playing field on each player turn.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.CLI
{
    using System;
    using System.Text;
    using Minesweeper.Core;
    using Minesweeper.Core.Field;
    using Minesweeper.Core.Mines;

    /// <summary>
    /// Prints the playing field after each player's turn.
    /// </summary>
    internal class GamePrinter
    {
        /// <summary>
        /// Symbol of a mine, which was hit by the player.
        /// </summary>
        private const string MineOpened = "*  ";

        /// <summary>
        /// Symbol of a cell, which has not been opened yet.
        /// </summary>
        private const string CellClosed = "\u25A0  ";

        /// <summary>
        /// Symbol of a cell, flagged as a mine.
        /// </summary>
        private const string Flag = "F  ";

        /// <summary>
        /// String builder for optimized printing on the console.
        /// </summary>
        private StringBuilder sb;

        /// <summary>
        /// Initializes a new instance of the GamePrinter class.
        /// </summary>
        internal GamePrinter()
        {
            this.sb = new StringBuilder();
        }

        /// <summary>
        /// Prints the playing field on each turn.
        /// </summary>
        /// <param name="playingField">Current playing field.</param>
        /// <param name="gamestatus">Status of the game, currently being played.</param>
        internal void PrintPlayingField(PlayingField playingField, GameStatus gamestatus)
        {
            MenuPrinter menuPrinter = new MenuPrinter();
            menuPrinter.ConsoleSetUp();
            menuPrinter.PrintBackground();

            int rows = playingField.Field.GetLength(0);
            int columns = playingField.Field.GetLength(1);

            string formatString = new string(' ', (Console.WindowWidth - (columns + (columns * 2))) / 2);

            this.sb.AppendLine();
            this.sb.Append(formatString);

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append(string.Format("{0}", i).PadLeft(2, ' ') + " ");
            }

            this.sb.AppendLine();
            this.PrintLine(columns);

            for (int i = 0; i < rows; i++)
            {
                this.sb.Append(new string(' ', ((Console.WindowWidth - (columns + (columns * 2))) / 2) - 4));
                this.sb.Append(string.Format("{0}", i).PadLeft(2, ' '));
                this.sb.Append(" | ");

                for (int j = 0; j < columns; j++)
                {
                    Cell currentField = playingField.Field[i, j];

                    if (gamestatus == GameStatus.GameOn)
                    {
                        if (currentField.Status == CellStatus.Opened)
                        {
                            this.sb.Append(playingField.Field[i, j].Value);
                            this.sb.Append("  ");
                        }
                        else if (currentField.Status == CellStatus.Flagged)
                        {
                            this.sb.Append(Flag);
                        }
                        else
                        {
                            this.sb.Append(CellClosed);
                        }
                    }
                    else if (gamestatus == GameStatus.GameOver)
                    {
                        if (currentField.IsMine)
                        {
                            this.sb.Append(MineOpened);
                        }
                        else
                        {
                            this.sb.Append(playingField.Field[i, j].Value + "  ");
                        }
                    }
                    else
                    {
                        if (currentField.IsMine == true || currentField.Status == CellStatus.Flagged)
                        {
                            this.sb.Append(Flag);
                        }
                        else
                        {
                            this.sb.Append(playingField.Field[i, j].Value + "  ");
                        }
                    }
                }

                this.sb.Append("|");
                this.sb.AppendLine();
            }

            this.PrintLine(columns);
            Console.WriteLine(this.sb.ToString());
            this.sb.Clear();
        }

        /// <summary>
        /// Print a line on the console.
        /// </summary>
        /// <param name="columns">The number of columns in the playing field.</param>
        private void PrintLine(int columns)
        {
            this.sb.Append(new string(' ', (Console.WindowWidth - (columns + (columns * 2))) / 2));

            for (int i = 0; i < columns; i++)
            {
                this.sb.Append("===");
            }

            this.sb.Append("=");
            this.sb.AppendLine();
        }
    }
}