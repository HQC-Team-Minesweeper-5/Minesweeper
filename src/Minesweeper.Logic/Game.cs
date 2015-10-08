namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public sealed class Game
    {
        private const int MaxRows = 5;
        private const int MaxColumns = 10;
        private const int MaxMines = 15;
        private const int MaxTopPlayers = 5;
        private const string GameWelcomeText = "Welcome to the game “Minesweeper. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private const string InvalidCoordinatesText = "Illegal move";
        private const string GameEndMessage = "Your score: ";
        private const string RestartMessage = "Press 'enter' for new game";

        private static Game gameInstance;
        //private static volatile Game gameInstance;
        //private static object lockThis = new object();
        private PlayingField gameBoard;
        private GameStatus gameStatus;
        private Printer printer;
        private bool initialState;

        private Game()
        {
            this.gameStatus = GameStatus.GameOn;
            this.printer = new Printer();
            this.StartNewGame();
        }

        public static Game Instance()
        {
            if (gameInstance == null)
            {
                //lock (lockThis)
                //{
                //    if (gameInstance == null)
                //    {
                gameInstance = new Game();
                //    }
                //}
            }

            return gameInstance;
        }

        // State pattern?
        private void StartNewGame()
        {
            this.gameBoard = new PlayingField(MaxRows, MaxColumns, MaxMines);
            int choosenRow = 0;
            int chosenColumn = 0;
            bool flag = false;
            string inputCommand;
            string[] inputCoordinates;
            this.initialState = true;

            Scoreboard.Initialize(MaxTopPlayers);  // TODO: Find more appropriate place for the scoreboard
            Console.WriteLine(GameWelcomeText);

            while (this.gameStatus != GameStatus.Restart)
            {
                switch (this.gameStatus)
                {
                    case GameStatus.GameOn:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);

                        bool areCoordinatesValid;
                        int score;
                        do
                        {
                            Console.Write("\r\nEnter coordinates in format [Row Col]: ");
                            inputCommand = Console.ReadLine();
                            inputCoordinates = inputCommand.Split(' ');
                            bool isValidIntRow = int.TryParse(inputCoordinates[0], out choosenRow);
                            bool isValidIntCol = false;

                            if (isValidIntRow && inputCoordinates.Length > 1)
                            {
                                isValidIntCol = int.TryParse(inputCoordinates[1], out chosenColumn);
                            }

                            areCoordinatesValid = isValidIntRow && isValidIntCol && choosenRow >= 0 && choosenRow < MaxRows && chosenColumn >= 0 && chosenColumn < MaxColumns;

                            if (!areCoordinatesValid)
                            {
                                Console.WriteLine(InvalidCoordinatesText);
                            }
                        }
                        while (!areCoordinatesValid);

                        if (inputCoordinates.Length > 2 && inputCoordinates[2] == "f")
                        {
                            this.gameBoard.SetFlag(choosenRow, chosenColumn);
                        }
                        else if (inputCoordinates.Length > 2 && inputCoordinates[2] == "r")
                        {
                            this.gameBoard.RemoveFlag(choosenRow, chosenColumn);
                        }
                        else
                        {
                            this.gameStatus = this.gameBoard.OpenCell(choosenRow, chosenColumn);
                        }

                        // Initializes mines & calculates field values if the game has just started
                        if (initialState)
                        {
                            this.gameBoard.SetMines(MaxMines);
                            MineCalculator.CalculateFieldValues(this.gameBoard.Field);
                            initialState = false;
                        }

                        if (gameBoard.OpenCellsCounter == MaxRows * MaxColumns - MaxMines)
                        {
                            this.gameStatus = GameStatus.YouWin;
                        }

                        break;

                    case GameStatus.GameOver:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);
                        score = MineCalculator.CountOpenMines(this.gameBoard.Field);
                        Console.WriteLine("{0} {1}", GameEndMessage, score);
                        Scoreboard.CheckHighScores(score);
                        this.gameStatus = GameStatus.Restart;
                        break;

                    case GameStatus.YouWin:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);
                        Console.WriteLine("Congratulations General, you won the game!");
                        this.gameStatus = GameStatus.GameOver;
                        break;

                    default:
                        throw new Exception("Invalid game state!");
                }

            }

            Console.WriteLine("{0}", RestartMessage);
            Console.ReadLine();
            Console.Clear();
            this.gameStatus = GameStatus.GameOn;
            this.StartNewGame();
        }
    }
}
