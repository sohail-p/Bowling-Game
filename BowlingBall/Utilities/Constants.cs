namespace BowlingBall.Utilities
{
    public class Constants
    {
        /// <summary>
        /// Constant for determining total number of frames
        /// </summary>
        public const int MAX_FRAMES = 10;
    }

    /// <summary>
    /// Enums for defining types of frames:
    /// Strike - All 10 pins knocked in 1 roll 
    /// Spare - All 10 pins knocked in 2 rolls
    /// Normal - Less than 10 pins knocked in all the rolls
    /// </summary>
    public enum RollType
    {
        Strike,
        Spare,
        Normal
    }
}
