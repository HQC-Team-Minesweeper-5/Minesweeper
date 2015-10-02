namespace Minesweeper.Logic.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void CompareHigherToLowerTest()
        {
            Player firstPlayer = new Player("First Player", 100);
            Player secondPlayer = new Player("Second Player", 2);

            Assert.AreEqual(firstPlayer.CompareTo(secondPlayer), -1);
        }

        [TestMethod]
        public void CompareLowerToHigherTest()
        {
            Player firstPlayer = new Player("First Player", 100);
            Player secondPlayer = new Player("Second Player", 2);

            Assert.AreEqual(secondPlayer.CompareTo(firstPlayer), 1);
        }

        [TestMethod]
        public void CompareEqual()
        {
            Player onlyPlayer = new Player("Sasho", 100);
            
            Assert.AreEqual(onlyPlayer.CompareTo(onlyPlayer), 0);
        }
    }
}