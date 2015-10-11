//-----------------------------------------------------------------------
// <copyright file="GameStatus.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This enumeration lists the different states of the minesweeper game.</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core
{
    /// <summary>
    /// Enumeration with the different states of the minesweeper game.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// State where the game is currently being played.
        /// </summary>
        GameOn,

        /// <summary>
        /// State where player has won the game.
        /// </summary>
        YouWin,

        /// <summary>
        /// State where the game will be restarted.
        /// </summary>
        Restart,

        /// <summary>
        /// State where the game is over.
        /// </summary>
        GameOver
    }
}
