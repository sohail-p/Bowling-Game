using BowlingBall.Utilities;
using System.Linq;

namespace BowlingBall.Models
{
    public class LastFrame : FrameBase
    {
        /// <summary>
        /// Overridden Method to check if current frame is done or not, last frame will have 3 rolls incase of Spare / Strike
        /// Frame is done 
        /// if there are 2 rolls and knocked pins collectively are less than 10
        ///         OR
        /// if pins knocked are = 10 in 1 roll or 3 rolls
        /// </summary>
        /// <returns></returns>
        public override bool IsFrameDone()
        {
            return RollType == RollType.Normal && Rolls.Count == 2
                   || RollType == RollType.Spare && Rolls.Count == 3
                   || RollType == RollType.Strike && Rolls.Count == 3;
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
