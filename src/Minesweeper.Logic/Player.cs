namespace Minesweeper.Logic
{
    using System;

    public class Player : IComparable
    {
        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; }

        public int Score { get; }

        public int CompareTo(object obj)
        {
            if (!(obj is Player))
            {
                throw new ArgumentException(
                   "A Player object is required for comparison.");
            }

            return -1 * this.Score.CompareTo(((Player)obj).Score);
        }

        public override string ToString()
        {
            string result = this.Name + " --> " + this.Score;
            return result;
        }
    }
}
