namespace Minesweeper.Logic
{
    public class Coordinates
    {
        private int maxRows;
        private int maxColumns;
        private int choosenRow;
        private int choosenColumn;

        public Coordinates(int maxRows, int maxColumns)
        {
            this.maxRows = maxRows;
            this.maxColumns = maxColumns;
        }

        public int ChoosenRow
        {
            get { return this.choosenRow; }
            private set { this.choosenRow = value; }
        }

        public int ChoosenColumn
        {
            get { return this.choosenColumn; }
            private set { this.choosenColumn = value; }
        }

        public bool AreCordinatesInRange(int choosenRow, int choosenColumn)
        {
            bool validRow = choosenRow >= 0 && choosenRow < this.maxRows;
            bool validColumn = choosenColumn >= 0 && choosenColumn < this.maxColumns;
            if (validRow && validColumn)
            {
                this.ChoosenRow = choosenRow;
                this.ChoosenColumn = choosenColumn;
                return true;
            }

            return false;
        }
    }
}
