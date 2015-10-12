namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Utils;

    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void CreatingAScoreShouldCreateANewScore()
        {
            Score someScore = new Score("Pesho", 5, new DateTime(2000, 1, 1));

            Assert.AreEqual(5, someScore.Points);
        }

        [TestMethod]
        public void ComparingTheSameScoresShouldReturnZero()
        {
            Score someScore = new Score("Pesho", 5, new DateTime(2000, 1, 1));
            Score otherScore = new Score("Pesho", 5, new DateTime(2000, 1, 1));
            Assert.AreEqual(0, someScore.CompareTo(otherScore));
        }

        [TestMethod]
        public void ComparingABiggerToSmallerScoreShouldReturnOne()
        {
            Score biggerScore = new Score("Pesho", 6, new DateTime(2000, 1, 1));
            Score smallerScore = new Score("Pesho", 5, new DateTime(2000, 1, 1));
            Assert.AreEqual(1, biggerScore.CompareTo(smallerScore));
        }

        [TestMethod]
        public void ComparingASmallerToBiggerScoreShouldReturnMinusOne()
        {
            Score biggerScore = new Score("Pesho", 6, new DateTime(2000, 1, 1));
            Score smallerScore = new Score("Pesho", 55, new DateTime(2000, 1, 1));
            Assert.AreEqual(-1, biggerScore.CompareTo(smallerScore));
        }

        [TestMethod]
        public void ToStringShouldReturnAStringInSelectedFormat()
        {
            Score someScore = new Score("Pesho", 6, new DateTime(2000, 1, 1));
            Assert.AreEqual("Pesho" + "\t" + "6" + "\t" + new DateTime(2000, 1, 1).ToString() , someScore.ToString());
        }
    }
}
