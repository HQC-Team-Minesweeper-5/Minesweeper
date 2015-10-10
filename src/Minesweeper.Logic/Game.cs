namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;
    using Minesweeper.Logic.Interfaces;

    public sealed class Game
    {
        private const int consoleHeight = 29;
        private const int consoleWidth = 80;
        private int numberOfRows = 9;
        private int numberOfCols = 9;
        private int numberOfMines = 10;
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
            //Facade
            PrepareGameResourses();
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

        private void PrepareGameResourses()
        {
            MenuPrinter.ConsoleSetUp();
            SelectLevel(MenuPrinter.GameLevelSelector());
            MenuPrinter.PrintBackground();

            if (numberOfMines != 0)
            {
                this.gameStatus = GameStatus.GameOn;
            }
            else
            {
                this.gameStatus = GameStatus.GameOver;
            }


            this.printer = new Printer();
            this.coordinates = new Coordinates(numberOfRows, numberOfCols);
            this.userInput = new ConsoleUserInput();
        }

        // State pattern?
        private void StartNewGame()
        {
            this.gameBoard = new PlayingField(numberOfRows, numberOfCols, numberOfMines);

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

                        if (this.gameBoard.OpenCellsCounter == (numberOfRows * numberOfCols) - numberOfMines)
                        {
                            this.gameStatus = GameStatus.YouWin;
                        }

                        Console.Clear();
                        break;

                    case GameStatus.GameOver:
                        this.printer.PrintPlayingField(this.gameBoard, this.gameStatus);
                        Console.ReadKey();
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

        private void SelectLevel(int level)
        {
            switch (level)
            {
                case 1:
                    numberOfRows = 9;
                    numberOfCols = 9;
                    numberOfMines = 10;
                    break;
                case 2:
                    numberOfRows = 14;
                    numberOfCols = 14;
                    numberOfMines = 30;
                    break;
                case 3:
                    numberOfRows = 14;
                    numberOfCols = 20;
                    numberOfMines = 70;
                    break;
                default:
                    numberOfMines = 0;
                    break;
            }
        }
    }
}
