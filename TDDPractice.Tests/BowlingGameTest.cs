using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Game game;
        [TestInitialize]
        public void SetUp()
        {
            game = new Game();
        }
        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }
        public void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }
        public void RollStrike()
        {
            game.Roll(10);
        }

        [TestMethod]
        public void GutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }
        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }
        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, game.Score());
        }
        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score());
        }
        [TestMethod]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }
    }
}
