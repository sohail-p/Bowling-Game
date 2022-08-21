using BowlingBall.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall.Models
{
    /// <summary>
    /// Abstract class Frame base to serve different frames
    /// </summary>
    public abstract class FrameBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        protected FrameBase()
        {
            Rolls = new List<int>();
        }

        /// <summary>
        /// Property for Rolls
        /// </summary>
        public List<int> Rolls { get; set; }

        /// <summary>
        /// Method to indicate whether current frame is having any pending rolls
        /// </summary>
        /// <returns></returns>
        public abstract bool IsFrameDone();

        /// <summary>
        /// Roll Type to show if its a Spare / Strike / Normal
        /// </summary>
        public virtual RollType RollType { get; } = RollType.Normal;

        /// <summary>
        /// Method to calculate score for this particular frame
        /// </summary>
        public int Score => Rolls.Sum();

        /// <summary>
        /// Method for showing how many pins were knocked in that roll
        /// </summary>
        /// <param name="pins"></param>
        public void AddRolls(int pins)
        {
            Rolls.Add(pins);
        }
    }
}
