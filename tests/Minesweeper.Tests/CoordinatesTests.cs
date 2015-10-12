namespace Minesweeper.Tests.UitlsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Utils;

    [TestClass]
    public class CoordinatesTests
    {
        private readonly int row = 5;
        private readonly int column = 5;

        [TestMethod]
        public void InitializingCoordinatesShouldNowThrow()
        {
            var coordinate = new Coordinates(this.row, this.column);
        }

        public void RowShouldBeInt()
        {
            var coordinate = new Coordinates(this.row, this.column);
            Assert.IsInstanceOfType(coordinate.Row, typeof(int));
        }

        public void ColShouldBeInt()
        {
            var coordinate = new Coordinates(this.row, this.column);
            Assert.IsInstanceOfType(coordinate.Col, typeof(int));
        }
    }
}
