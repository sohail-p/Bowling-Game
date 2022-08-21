using BowlingBall.Models;
using System.Collections.Generic;

namespace BowlingBall.Utilities
{
    public class UtilityFunctions
    {
        /// <summary>
        /// Calculate Cumnulative Score of all the frames
        /// </summary>
        /// <param name="frames"></param>
        /// <returns></returns>
        public static int CalculateScore(List<FrameBase> frames)
        {
            int score = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                score += frames[i].Score + CalculateBonus(frames, i);
            }

            return score;
        }

        /// <summary>
        /// Calculate Bonus points
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int CalculateBonus(List<FrameBase> frames, int index)
        {
            FrameBase frame = frames[index];
            if (frame is LastFrame)
            {
                return 0;
            }

            switch (frame.RollType)
            {
                case RollType.Normal:
                    return 0;
                case RollType.Spare:
                    return frames[index + 1].Rolls[0];
                case RollType.Strike:
                    return frames[index + 1].Rolls.Count > 1
                        ? frames[index + 1].Rolls[0] + frames[index + 1].Rolls[1]
                        : frames[index + 1].Rolls[0] + frames[index + 2].Rolls[0];
            }

            return 0;
        }
    }
}
