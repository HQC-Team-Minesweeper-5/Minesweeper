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
