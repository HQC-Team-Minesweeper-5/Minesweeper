using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    // TODO: Implement it as a pattern, probably prototype (i.e implement IClonable)
    public class Field
    {
        private int value;
        private FieldStatus status;

        public enum FieldStatus { Closed, Opened, IsAMine }

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
    }
}
