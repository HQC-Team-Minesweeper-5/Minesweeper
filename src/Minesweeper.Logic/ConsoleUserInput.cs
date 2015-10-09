namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Interfaces;

    public class ConsoleUserInput : IUserInput
    {
        private const string InvalidCoordinatesText = "Illegal move";
        private const string EnterCordinates = "\r\nEnter coordinates in format [Row Col]: ";
        private int choosenRow;
        private int choosenColumn;

        public string[] InputCoordinates { get; set; }

        public int ChoosenRow
        {
            get
            {
                return this.choosenRow;
            }

            set
            {
                this.choosenRow = value;
            }
        }

        public int ChoosenColumn
        {
            get
            {
                return this.choosenColumn;
            }

            set
            {
                this.choosenColumn = value;
            }
        }

        public void HandleUserInput()
        {
            Console.Write(EnterCordinates);
            string inputCommand = Console.ReadLine();
            this.InputCoordinates = inputCommand.Split(' ');
            this.Validate(this.InputCoordinates);
        }

        private void Validate(string[] inputCordinates)
        {
            string inputRow = string.Empty;
            string inputColumn = string.Empty;
            bool isValid = true;
            if (inputCordinates.Length < 2)
            {
                isValid = false;
            }
            else
            {
                inputRow = inputCordinates[0];
                inputColumn = inputCordinates[1];
                bool isValidIntRow = int.TryParse(inputRow, out this.choosenRow);
                bool isValidIntCol = int.TryParse(inputColumn, out this.choosenColumn);
                if (!(isValidIntRow && isValidIntCol))
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                Console.WriteLine(InvalidCoordinatesText);
                this.HandleUserInput();
            }      
        }
    }
}