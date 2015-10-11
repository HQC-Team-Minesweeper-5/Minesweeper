namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;
    using Minesweeper.Logic.Enumerations;
    using Minesweeper.Logic.Structures;

    public class HandleUserInput
    {
        private const string InvalidCoordinatesText = "Illegal move";
        private const string EnterCordinates = "\r\nEnter coordinates in format [Row Col]: ";

        public string[] InputCoordinates { get; set; }

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
                            List<CellCoordinates> lastTurnCells = Game.Instance().OpenCellSaver.GetLastCells();

                            if (lastTurnCells == null)
                            {
                                //Console.WriteLine("You have no moves to undo!");
                            }
                            else
                            {
                                int howManyFieldsOpenedLast = 0;
                                foreach (var cell in lastTurnCells)
                                {
                                    if (playingField.Field[cell.Row, cell.Col].Status == FieldStatus.Closed)
                                        playingField.Field[cell.Row, cell.Col].Status = FieldStatus.Flagged;
                                    else
                                    {
                                        playingField.Field[cell.Row, cell.Col].Status = FieldStatus.Closed;
                                        howManyFieldsOpenedLast++;
                                    }
                                }
                                Game.Instance().OpenCellSaver.RemoveCells();
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
                            Game.Instance().NumberOfFlags++;
                            break;
                        }
                        else if (this.InputCoordinates[2].ToLower() == "r")
                        {
                            playingField.RemoveFlag(row, col);
                            Game.Instance().NumberOfFlags--;
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