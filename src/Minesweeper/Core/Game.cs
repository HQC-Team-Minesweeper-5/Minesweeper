//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This file contains the core logic for our minesweeper game</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core
{
    using System;
    using System.Threading.Tasks;
    using Minesweeper.CLI;
    using Minesweeper.Core.Field;
    using Minesweeper.Utils;

    /// <summary>
    /// Core class containing game logic and initialization.
    /// </summary>
    public sealed class Game
    {
        /// <summary>
        /// Message that alerts user for input of an invalid move or command.
        /// </summary>
        private const string InvalidCoordinatesText = "Illegal move or invalid command!";

        /// <summary>
        /// Game over message.
        /// </summary>
        private const string GameOverMessage = "GAME OVER - you are dead!";
       
        /// <summary>
        /// Win message.
        /// </summary>
        private const string YouWinMessage = "Congratulations General, you just won the game!";

        /// <summary>
        /// Message showing current user score.
        /// </summary>
        private const string ScoreMessage = "Your score: ";
        /// <summary>
        /// Message helping user with command input.
        /// </summary>
        private const string ExitOrRestartMessage = "Enter 'restart' for new game or 'exit' to exit the game";

        /// <summary>
        /// Game welcome text.
        /// </summary>
        private const string GameWelcomeText = "Welcome to the game “Minesweeper. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";

        /// <summary>
        /// Error message for invalid end state. You should never see this.
        /// </summary>
        private const string InvalidGameStateMessage = "Invalid game state!";

        /// <summary>
        /// Field containing the current game instance.
        /// </summary>
        private static Game gameInstance;

        /// <summary>
        /// Field containing the current playing field number of rows.
        /// </summary>
        private int numberOfRows;

        /// <summary>
        /// Field containing the current playing field number of columns.
        /// </summary>
        private int numberOfCols;

        /// <summary>
        /// Field containing current game status.
        /// </summary>
        private GameStatus gameStatus;

        /// <summary>
        /// Field holding an instance of the game printer.
        /// </summary>
        private GamePrinter gamePrinter;

        /// <summary>
        /// Field holding an instance, handling user input.
        /// </summary>
        private UserInput userInput;

        /// <summary>
        /// Field holding an instance of the music player.
        /// </summary>
        private MusicPlayer musicPlayer;

        /// <summary>
        /// Prevents a default instance of the Game class from being created. This constructor initializes instances of all classes, that are needed for the game play.
        /// </summary>
        private Game()
        {
            this.gamePrinter = new GamePrinter();
            this.userInput = new UserInput();
            this.Memento = new Memento();
            this.musicPlayer = new MusicPlayer();
            this.gameStatus = GameStatus.GameOn;
        }

        /// <summary>
        /// Gets the playing field.
        /// </summary>
        /// <value>The GameBoard property gets/sets the game board.</value>
        public PlayingField GameBoard { get; private set; }

        /// <summary>
        /// Gets the memento, enabling the undo functionality.
        /// </summary>
        /// <value>The Memento property gets/sets the memento.</value>
        public Memento Memento { get; private set; }

        /// <summary>
        /// Gets the number of mines, currently placed on the playing field.
        /// </summary>
        /// <value>The NumberOfMines property gets/sets the number of mines on the game board.</value>
        public int NumberOfMines { get; private set; }

        /// <summary>
        /// Gets or sets the number of flags, currently placed on the playing field.
        /// </summary>
        /// <value>The NumberOfFlags property gets/sets the number of flags, currently placed on the playing field.</value>
        public int NumberOfFlags { get; set; }

        /// <summary>
        /// Game class is initialized as a Singleton, to ensure that it is done only once.
        /// </summary>
        /// <returns>Singleton instance of the Game class.</returns>
        public static Game Instance()
        {
            if (gameInstance == null)
            {
                gameInstance = new Game();
            }

            return gameInstance;
        }

        /// <summary>
        /// Starts and then controls the state of the game.
        /// </summary>
        public void StartNewGame()
        {
            this.PrepareGameResources();
            Console.WriteLine(GameWelcomeText);

            while (this.gameStatus != GameStatus.Restart)
            {
                switch (this.gameStatus)
                {
                    case GameStatus.GameOn:
                        this.DisplayGameOnSection();

                        break;

                    case GameStatus.GameOver:
                        this.DisplayGameOverSection();
                        break;

                    case GameStatus.YouWin:
                        this.DisplayYouWinSection();
                        break;

                    default:
                        throw new Exception(InvalidGameStateMessage);
                }
            }
        }

        /// <summary>
        /// Helper method that restarts the game.
        /// </summary>
        public void RestartGame()
        {
            Console.Clear();

            this.gameStatus = GameStatus.GameOn;
            this.StartNewGame();
        }

        /// <summary>
        /// Helper method that finishes the game.
        /// </summary>
        public void ChangeToGameOver()
        {
            Console.Clear();

            this.gameStatus = GameStatus.GameOver;
        }

        /// <summary>
        /// Helper method that during each turn in the game prints the playing field and invokes the method that handles the user input.
        /// </summary>
        private void DisplayGameOnSection()
        {
            this.gamePrinter.PrintPlayingField(this.GameBoard, this.gameStatus);
            this.userInput.HandleInput(this.GameBoard);

            // Check if the game has been completed
            if (this.GameBoard.OpenCellsCounter == (this.numberOfRows * this.numberOfCols) - this.NumberOfMines)
            {
                this.gameStatus = GameStatus.YouWin;
            }

            Console.Clear();
        }

        /// <summary>
        /// Helper method that sets the level of the game to one of the 3 predefined states.
        /// </summary>
        /// <param name="level">Parameter holds the level characteristics - dimensions of the playing field and number of mines.</param>
        private void SelectLevel(Level level)
        {
            this.numberOfRows = level.NumberOfRows;
            this.numberOfCols = level.NumberOfCols;
            this.NumberOfMines = level.NumberOfMines;
        }

        /// <summary>
        /// Helper method that initializes game resources - prints the menu and prepares the playing field.
        /// </summary>
        private void PrepareGameResources()
        {
            MenuPrinter menuPrinter = new MenuPrinter();

            this.SelectLevel(menuPrinter.GameLevelSelector());
            this.GameBoard = new PlayingField(this.numberOfRows, this.numberOfCols, this.NumberOfMines);

            menuPrinter.ConsoleSetUp();
            menuPrinter.PrintBackground();
        }

        /// <summary>
        /// Helper method that displays a congratulation message and plays a cheering sound if player has won the game.
        /// </summary>
        private void DisplayYouWinSection()
        {
            Console.WriteLine(YouWinMessage);
            this.musicPlayer.PlayWinMusic();
            Scoreboard.HighScore(this.GameBoard.OpenCellsCounter);
            Console.ReadKey();

            this.gameStatus = GameStatus.Restart;
        }

        /// <summary>
        /// Helper method that ends the game in case player has stepped on a mine.
        /// </summary>
        private void DisplayGameOverSection()
        {
            this.musicPlayer.PlayGameOverMusic();
            this.gamePrinter.PrintPlayingField(this.GameBoard, this.gameStatus);
            this.gameStatus = GameStatus.Restart;

            Scoreboard.HighScore(this.GameBoard.OpenCellsCounter);
            int score = this.GameBoard.OpenCellsCounter;
            Console.WriteLine(GameOverMessage);
            Console.WriteLine("{0} {1}", ScoreMessage, score);
            Console.ReadKey();
        }
    }
}
