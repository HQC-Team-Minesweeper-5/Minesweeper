namespace Minesweeper.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Core.Field;

    [TestClass]
    public class PlayingFieldTests
    {
        [TestMethod]
        public void CreatingPlayingFieldShouldCreateMinesweeperPlayingField()
        {
            PlayingField sampleField = new PlayingField(3, 4, 1);
            Assert.AreEqual(3, sampleField.Field.GetLength(0));
            Assert.AreEqual(4, sampleField.Field.GetLength(1));
        }

        [TestMethod]
        public void WhenNewFieldIsCreatedOpenCellsCounterShouldBeZero()
        {
            PlayingField sampleField = new PlayingField(3, 4, 1);
            Assert.AreEqual(0, sampleField.OpenCellsCounter);
        }

        [TestMethod]
        public void OpeningCellsShouldIncreaseTheOpenCellCounter()
        {
            PlayingField sampleField = new PlayingField(3, 4, 1);
            sampleField.OpenCell(0, 0);
            Assert.AreNotEqual(0, sampleField.OpenCellsCounter);
        }

        [TestMethod]
        public void ReduceScoreShouldReduceTheNumberOfOpenPlayingFields()
        {
            PlayingField sampleField = new PlayingField(3, 4, 1);
            sampleField.OpenCell(0, 0);
            int scoreAfterFirstMove = sampleField.OpenCellsCounter;
            sampleField.ReduceScore(1);
            Assert.AreNotEqual(scoreAfterFirstMove, sampleField.OpenCellsCounter);
        }
    }
}
