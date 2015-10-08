namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public class MineCell : ICloneable
    {
        private int value;
        private bool isMine;
        private FieldStatus status;

        public MineCell()
        {
            this.value = 0;
            this.status = FieldStatus.Closed;
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public FieldStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public bool IsMine
        {
            get { return this.isMine; }
            set { this.isMine = value; }
        }

        public object Clone()
        {
            return this.MemberwiseClone() as MineCell;
        }
    }
}
