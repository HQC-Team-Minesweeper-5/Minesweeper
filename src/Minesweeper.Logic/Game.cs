namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;
    using Minesweeper.Logic.Interfaces;

    public sealed class Game
    {
        private const int MaxRows = 9;
        private const int MaxColumns = 9;
        private const int MaxMines = 10;
        private const int MaxTopPlayers = 5;
        private const string GameWelcomeText = "Welcome to the game “Minesweeper. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private const string InvalidCoordinatesText = "Illegal move";
        private const string GameEndMessage = "Your score: ";
        private const string RestartMessage = "Press 'enter' for new game";

        private static Game gameInstance;
        private PlayingField gameBoard;
        private GameStatus gameStatus;
        private Printer printer;
        private Coordinates coordinates;
        private IUserInput userInput;
        private Game()
        {
            this.gameStatus = GameStatus.GameOn;
            this.printer = new Printer();
            this.coordinates = new Coordinates(MaxRows, MaxColumns);
            this.userInput = new ConsoleUserInput();
            this.StartNewGame();
        }

        public static Game Instance()
        {
            if (gameInstance == null)
            {
                gameInstance = new Game();
            }

            return gameInstance;
        }

        // State pattern?
        private void StartNewGame()
        {
            this.gameBoard = new PlayingField(MaxRows, MaxColumns, MaxMines);

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
                            userInput.HandleUserInput();
                            areCoordinatesValid = coordinates.AreCordinatesInRange(userInput.ChoosenRow, userInput.ChoosenColumn);
                            if (!areCoordinatesValid)
                            {
                                Console.WriteLine(InvalidCoordinatesText);
                            }
                        }
                        while (!areCoordinatesValid);

                        if ((userInput.InputCoordinates.Length > 2 && userInput.InputCoordinates[2].ToLower() == "f"))
                        {
                            this.gameBoard.SetFlag(coordinates.ChoosenRow, coordinates.ChoosenColumn);
                        }
                        else if ((userInput.InputCoordinates.Length > 2 && userInput.InputCoordinates[2].ToLower() == "r"))
                        {
                            this.gameBoard.RemoveFlag(coordinates.ChoosenRow, coordinates.ChoosenColumn);
                        }
                        else
                        {
                            this.gameStatus = this.gameBoard.OpenCell(coordinates.ChoosenRow, coordinates.ChoosenColumn);
                        }

                        if (this.gameBoard.OpenCellsCounter == (MaxRows * MaxColumns) - MaxMines)
                        {
                            this.gameStatus = GameStatus.YouWin;
                        }

                        Console.Clear();
                        break;

                    case GameStatus.GameOver:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);
                        score = this.gameBoard.OpenCellsCounter;
                        Console.WriteLine("GAME OVER - you are dead!");
                        Console.WriteLine("{0} {1}", GameEndMessage, score);

                        Scoreboard.HighScore(this.gameBoard.OpenCellsCounter);
                        this.gameStatus = GameStatus.Restart;
                        break;

                    case GameStatus.YouWin:
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
