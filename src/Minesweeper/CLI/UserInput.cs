//-----------------------------------------------------------------------
// <copyright file="UserInput.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This class contains the logic which takes care of the minesweeper player input on the console.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.CLI
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Core;
    using Minesweeper.Core.Field;
    using Minesweeper.Utils;

    /// <summary>
    /// Class taking care of the player input on the console.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Invalid coordinates warning message.
        /// </summary>
        private const string InvalidCoordinatesText = "Illegal move";

        /// <summary>
        /// Enter coordinates prompt message.
        /// </summary>
        private const string EnterCordinates = "\r\nEnter coordinates in format [Row Col]: ";

        /// <summary>
        /// Gets or sets the input coordinates.
        /// </summary>
        /// <value>Array with input coordinates.</value>
        public string[] InputCoordinates { get; set; }

        /// <summary>
        /// Method which takes care of anything the user inputs on the console during a minesweeper game.
        /// </summary>
        /// <param name="playingField">Method gets the current playing field.</param>
        public void HandleInput(PlayingField playingField)
        {
            int row;
            int col;
            int fieldRows = playingField.Field.GetLength(0);
            int fieldCows = playingField.Field.GetLength(1);

            bool isValid = false;
            while (!isValid)
            {
                Console.Write(EnterCordinates);
                string inputCommand = Console.ReadLine();
                this.InputCoordinates = inputCommand.Split(' ');

                if (this.InputCoordinates.Length == 1)
                {
                    switch (this.InputCoordinates[0])
                    {
                        case "restart":
                            Game.Instance().RestartGame();
                            isValid = true;
                            break;
                        case "exit":
                            Game.Instance().ChangeToGameOver();
                            isValid = true;
                            break;
                        case "undo":
                            List<Coordinates> lastTurnCells = Game.Instance().Memento.GetLastCells();

                            if (lastTurnCells == null)
                            {
                                Console.Beep(700, 400);
                                Console.Beep(700, 400);
                            }
                            else
                            {
                                int howManyFieldsOpenedLast = 0;
                                foreach (var cell in lastTurnCells)
                                {
                                    if (playingField.Field[cell.Row, cell.Col].Status == CellStatus.Closed)
                                    {
                                        playingField.Field[cell.Row, cell.Col].Status = CellStatus.Flagged;
                                        Game.Instance().NumberOfFlags += 1;
                                    }
                                    else if (playingField.Field[cell.Row, cell.Col].Status == CellStatus.Opened)
                                    {
                                        playingField.Field[cell.Row, cell.Col].Status = CellStatus.Closed;
                                        howManyFieldsOpenedLast++;
                                    }
                                    else
                                    {
                                        playingField.Field[cell.Row, cell.Col].Status = CellStatus.Closed;
                                        Game.Instance().NumberOfFlags -= 1;
                                    }
                                }

                                Game.Instance().Memento.RemoveCells();
                                playingField.ReduceScore(howManyFieldsOpenedLast);
                            }

                            isValid = true;
                            break;

                        default:
                            Console.WriteLine(InvalidCoordinatesText);
                            break;
                    }
                }
                else
                {
                    bool isValidIntRow = int.TryParse(this.InputCoordinates[0], out row) && row < fieldRows && row >= 0;
                    bool isValidIntCol = int.TryParse(this.InputCoordinates[1], out col) && col < fieldCows && col >= 0;

                    if (isValidIntRow && isValidIntCol && this.InputCoordinates.Length > 2)
                    {
                        if (this.InputCoordinates[2].ToLower() == "f")
                        {
                            playingField.SetFlag(row, col);
                            break;
                        }
                        else if (this.InputCoordinates[2].ToLower() == "r")
                        {
                            playingField.RemoveFlag(row, col);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(InvalidCoordinatesText);
                        }
                    }
                    else if (isValidIntRow && isValidIntCol)
                    {
                        playingField.OpenCell(row, col);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(InvalidCoordinatesText);
                    }
                }
            }
        }
    }
}