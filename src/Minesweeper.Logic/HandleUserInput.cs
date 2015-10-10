namespace Minesweeper.Logic
{
    using System;

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
                        default:
                            Console.WriteLine(InvalidCoordinatesText);
                            break;
                    }
                }
                else
                {
                    bool isValidIntRow = int.TryParse(this.InputCoordinates[0], out row) && row < fieldRows;
                    bool isValidIntCol = int.TryParse(this.InputCoordinates[1], out col) && col < fieldCows;

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