namespace Minesweeper.Core.Mines
{
    using System;
    using Minesweeper.Core.Field;

    public class Cell : ICloneable
    {
        public Cell()
        {
            this.Value = 0;
            this.Status = FieldStatus.Closed;
        }

        public int Value { get; set; }

        public FieldStatus Status { get; set; }

        public bool IsMine { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone() as Cell;
        }
    }
}
