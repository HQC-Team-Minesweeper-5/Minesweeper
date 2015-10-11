namespace Minesweeper.Core
{
    using System;
    using System.Threading;

    public class MusicPlayer
    {
        public void PlayWinMusic()
        {
            Console.Beep(600, 280);
            Console.Beep(500, 280);
            Console.Beep(600, 280);
            Console.Beep(600, 680);
        }

        public void PlayErrorSound()
        {
            Console.Beep(500, 280);
            Console.Beep(500, 280);
        }

        public void PlayGameOverMusic()
        {
            Console.Beep(800, 300);
            Console.Beep(600, 300);
            Console.Beep(400, 300);
        }

        public void PlayGameMusic()
        {
            const int soundLenght = 320;
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(587, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(262, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(415, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(587, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(262, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(587, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(262, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(415, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(622, soundLenght);
            Console.Beep(659, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(587, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(262, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(440, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(330, soundLenght);
            Console.Beep(523, soundLenght);
            Console.Beep(494, soundLenght);
            Console.Beep(440, soundLenght);
            Thread.Sleep(1000);
        }
    }
}
