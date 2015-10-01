namespace Minesweeper
{
    using Enumerations;
    using System;

    // TODO: Implement it as a pattern, probably prototype (i.e implement IClonable)
    public class Field : ICloneable
    {
        private int value;
        private FieldStatus status;
        
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

        public Field()
        {
            this.value = 0;
            this.status = FieldStatus.Closed;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
