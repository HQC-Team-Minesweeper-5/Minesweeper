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

        public int Value { get; set; }

        public FieldStatus Status { get; set; }

        public bool IsMine { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone() as MineCell;
        }
    }
}
