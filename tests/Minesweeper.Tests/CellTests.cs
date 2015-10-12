namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Core.Field;
    using Minesweeper.Core.Mines;

    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void InitializingNewCellShouldNotThrow()
        {
            var cell = new Cell();
        }

        [TestMethod]
        public void ValueShouldReturnInt()
        {
            var cell = new Cell();
            Assert.IsInstanceOfType(cell.Value, typeof(int));
        }

        [TestMethod]
        public void StatusShouldReturnCellStatus()
        {
            var cell = new Cell();
            Assert.IsInstanceOfType(cell.Status, typeof(CellStatus));
        }

        [TestMethod]
        public void IsMineShouldReturnBool()
        {
            var cell = new Cell();
            Assert.IsInstanceOfType(cell.IsMine, typeof(bool));
        }

        [TestMethod]
        public void CloneShouldReturnObject()
        {
            var cell = new Cell();
            Assert.IsInstanceOfType(cell.Clone(), typeof(Cell));
        }
    }
}
