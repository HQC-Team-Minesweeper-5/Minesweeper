//-----------------------------------------------------------------------
// <copyright file="MusicPlayer.cs" company="Team Minesweeper 5">
//     No copyright here. You can use whatever you want!
// </copyright>
// <summary>This file contains the music player for our minesweeper game</summary>
//-----------------------------------------------------------------------
namespace Minesweeper.Core
{
    using System;
    using System.Threading;

    /// <summary>
    /// The music player for the minesweeper game. This class is responsible for all sounds within our console game.
    /// </summary>
    public class MusicPlayer
    {
        /// <summary>
        /// Plays music when player has won the game.
        /// </summary>
        public void PlayWinMusic()
        {
            Console.Beep(600, 280);
            Console.Beep(500, 280);
            Console.Beep(600, 280);
            Console.Beep(600, 680);
        }

        /// <summary>
        /// Plays a sound when an error has been made.
        /// </summary>
        public void PlayErrorSound()
        {
            Console.Beep(500, 280);
            Console.Beep(500, 280);
        }

        /// <summary>
        /// Plays sound when the game is over.
        /// </summary>
        public void PlayGameOverMusic()
        {
            Console.Beep(800, 300);
            Console.Beep(600, 300);
            Console.Beep(400, 300);
        }

        /// <summary>
        /// Plays game music.
        /// </summary>
        public void PlayGameMusic()
        {
            const int SoundLenght = 320;
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(587, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(262, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(415, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(587, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(262, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(587, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(262, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(415, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(622, SoundLenght);
            Console.Beep(659, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(587, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(262, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(440, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(330, SoundLenght);
            Console.Beep(523, SoundLenght);
            Console.Beep(494, SoundLenght);
            Console.Beep(440, SoundLenght);
            Thread.Sleep(1000);
        }
    }
}
