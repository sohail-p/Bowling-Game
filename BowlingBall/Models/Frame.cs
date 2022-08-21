using BowlingBall.Utilities;
using System.Linq;

namespace BowlingBall.Models
{
    public class Frame : FrameBase
    {
        /// <summary>
        /// Overridden Method to check if current frame is done or not
        /// Frame is done 
        /// if there are 2 rolls
        ///         OR
        /// if pins knocked are = 10 in 1 roll or 2 rolls
        /// </summary>
        /// <returns></returns>
        public override bool IsFrameDone()
        {
            bool isStrike = RollType == RollType.Strike;

            bool isSpare = RollType == RollType.Spare;

            bool isNormalFrame = Rolls.Count == 2;


            return isStrike
                   || isSpare
                   || isNormalFrame;
        }

        /// <summary>
        /// Determines the Roll type
        /// Strike - First roll knocked 10 pins
        /// Spare - First Roll + Second Roll knocked 10 pins
        /// Normal - First Roll + Second Roll knocked less than 10 pins
        /// </summary>
        public override RollType RollType => Rolls.Any() && Rolls[0] == 10 ?
                                    RollType.Strike : Rolls.Sum() == 10 ?
                                    RollType.Spare : RollType.Normal;
    }
}
