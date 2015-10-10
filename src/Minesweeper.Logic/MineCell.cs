namespace Minesweeper.Logic
{
    using System;
    using Minesweeper.Logic.Enumerations;

    public class MineCell : ICloneable
    {
        public MineCell()
        {
            this.Value = 0;
            this.Status = FieldStatus.Closed;
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
