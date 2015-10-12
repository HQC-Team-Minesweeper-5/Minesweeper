namespace Minesweeper.Tests.UitlsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Utils;

    [TestClass]
    public class ScoreTests
    {
        private readonly string playerName = "Gosho";
        private readonly int points = 100;
        private readonly DateTime time = DateTime.Now;

        [TestMethod]
        public void InitializeNewScoreShouldNotThrow()
        {
            var score = new Score(this.playerName, this.points, this.time);
        }

        [TestMethod]
        public void ToStringShouldReturnString()
        {
            var score = new Score(this.playerName, this.points, this.time);
            var result = score.ToString();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void ToStringShouldReturnStringInProperFormat()
        {
            var score = new Score(this.playerName, this.points, this.time);
            var result = score.ToString();
            var template = String.Format("{0}\t{1}\t{2}", this.playerName, this.points, this.time);

            Assert.AreEqual(result, template);
        }

        [TestMethod]
        public void CompareToShouldReturnNumber()
        {
            const int FirstPoints = 100;
            const int SecondPoints = 100;

            var firstScore = new Score(this.playerName, FirstPoints, this.time);
            var secondScore = new Score(this.playerName, SecondPoints, this.time);

            var result = firstScore.CompareTo(secondScore);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        public void CompareToHigerShouldReturnMinusOne()
        {
            const int FirstPoints = 100;
            const int SecondPoints = 200;

            var firstScore = new Score(this.playerName, FirstPoints, this.time);
            var secondScore = new Score(this.playerName, SecondPoints, this.time);

            var result = firstScore.CompareTo(secondScore);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void CompareToEqualShouldReturnZero()
        {
            const int FirstPoints = 100;
            const int SecondPoints = 100;

            var firstScore = new Score(this.playerName, FirstPoints, this.time);
            var secondScore = new Score(this.playerName, SecondPoints, this.time);

            var result = firstScore.CompareTo(secondScore);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CompareToLowerShouldReturnOne()
        {
            const int FirstPoints = 100;
            const int SecondPoints = 50;

            var firstScore = new Score(this.playerName, FirstPoints, this.time);
            var secondScore = new Score(this.playerName, SecondPoints, this.time);

            var result = firstScore.CompareTo(secondScore);
            Assert.AreEqual(result, 1);
        }
    }
}
