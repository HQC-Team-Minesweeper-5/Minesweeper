namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Utils;

    [TestClass]
    public class LevelTests
    {
        private readonly int numberOfRows = 5;
        private readonly int numberOfCols = 5;
        private readonly int numberOfMines = 5;

        [TestMethod]
        public void InitializingLevelShouldNotThrow()
        {
            var level = new Level(this.numberOfRows, this.numberOfCols, this.numberOfMines);
        }

        [TestMethod]
        public void NumberOfRowsShouldBeInt()
        {
            var level = new Level(this.numberOfRows, this.numberOfCols, this.numberOfMines);
            Assert.IsInstanceOfType(level.NumberOfRows, typeof(int));
        }

        [TestMethod]
        public void NumberOfColsShouldBeInt()
        {
            var level = new Level(this.numberOfRows, this.numberOfCols, this.numberOfMines);
            Assert.IsInstanceOfType(level.NumberOfCols, typeof(int));
        }

        [TestMethod]
        public void NumberOfMinesShouldBeInt()
        {
            var level = new Level(this.numberOfRows, this.numberOfCols, this.numberOfMines);
            Assert.IsInstanceOfType(level.NumberOfMines, typeof(int));
        }
    }
        
        [TestMethod]
        public void CreateLevelShouldCreateNewLevel()
        {
            var newLevel = new Level(3, 4, 1);

            Assert.AreEqual(3, newLevel.NumberOfRows);
            Assert.AreEqual(4, newLevel.NumberOfCols);
            Assert.AreEqual(1, newLevel.NumberOfMines);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CreateLevelWithTooLargeNumberOfMinesShouldThrow()
        {
            var newLevel = new Level(3, 4, 13);
        }
    }
}
