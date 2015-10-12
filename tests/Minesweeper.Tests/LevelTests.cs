namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Utils;

    [TestClass]
    public class LevelTests
    {
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
