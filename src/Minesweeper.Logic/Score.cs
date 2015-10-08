namespace Minesweeper.Logic
{
    using System;

    internal class Score : IComparable<Score>
    {
        private string name;
        private int points;
        private DateTime date;

        public Score(string playerName, int points, DateTime dateTime)
        {
            this.name = playerName;
            this.points = points;
            this.date = dateTime;
        }

        public int Points
        {
            get
            {
                return this.points;
            }
        }

        public int CompareTo(Score otherScore)
        {
            if (this.points > otherScore.points)
            {
                return -1;
            }

            if (this.points == otherScore.points)
            {
                return 0;
            }

            return 1;
        }

        public override string ToString()
        {
            return this.name + "\t" + this.points.ToString() + "\t" + this.date.ToString();
        }
    }
}
