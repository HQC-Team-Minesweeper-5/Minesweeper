namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public class MineCell : ICloneable
    {
        private int value;
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

        public object Clone()
        {
            return this.MemberwiseClone() as MineCell;
        }
    }
}
