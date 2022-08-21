using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    /// <summary>
    /// Test class, using https://www.bowlinggenius.com/ as a refrence for expected answers
    /// </summary>
    [TestClass]
    public class GameFixture
    {
        /// <summary>
        /// Default test to check all gutter rolls
        /// </summary>
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            Game game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        /// <summary>
        /// Test to check if all are strikes
        /// </summary>
        [TestMethod]
        public void AllStrikes_test()
        {
            Game game = new Game();
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            Assert.AreEqual(300, game.GetScore());
        }

        /// <summary>
        /// Some random test considering same no of pins knocked in each roll
        /// </summary>
        [TestMethod]
        public void AllNormals_test()
        {
            Assert.AreEqual(60, AllNormals_Calc(3));
            Assert.AreEqual(20, AllNormals_Calc(1));
            Assert.AreEqual(145, AllNormals_Calc(5));
        }

        /// <summary>
        /// Test case from the porblem statement
        /// </summary>
        [TestMethod]
        public void RandomFrame_test()
        {
            int[] frameScore = new[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            Assert.AreEqual(187, GameTestFrameSet(frameScore));
            frameScore = new[] { 6, 4, 7, 3, 8, 2, 9, 1, 0, 10, 5, 5, 4, 6, 3, 7, 2, 8, 1, 9, 10 };
            Assert.AreEqual(149, GameTestFrameSet(frameScore));
        }

        /// <summary>
        /// Helper method to roll balls
        /// </summary>
        /// <param name="game"></param>
        /// <param name="pins"></param>
        /// <param name="times"></param>
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        /// <summary>
        /// Helper method to calc score considering same pins knocked each roll
        /// </summary>
        /// <param name="noPins"></param>
        /// <returns></returns>
        private int AllNormals_Calc(int noPins)
        {
            Game game = new Game();
            for (int i = 0; i < 20; i++)
            {
                game.Roll(noPins);
            }
            return game.GetScore();
        }

        /// <summary>
        /// Helper method to calc score based on input from array
        /// </summary>
        /// <param name="expectedScore"></param>
        /// <param name="frameScores"></param>
        public int GameTestFrameSet(int[] frameScores)
        {
            Game game = new Game();
            for (int i = 0; i < frameScores.Length; i++)
            {
                game.Roll(frameScores[i]);
            }
            return game.GetScore();
        }
    }
}
