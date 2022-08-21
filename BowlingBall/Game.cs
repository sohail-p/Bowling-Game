using BowlingBall.Models;
using BowlingBall.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    /// <summary>
    /// Main game class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// List of frames for a game
        /// </summary>
        private List<FrameBase> _frames { get; }

        /// <summary>
        /// Default constructor for intializing frames
        /// </summary>
        public Game()
        {
            _frames = new List<FrameBase>();
        }

        /// <summary>
        /// Action of rolling a ball
        /// </summary>
        /// <param name="pins">Pins knocked by the roll</param>
        public void Roll(int pins)
        {
            // Add a roll to existing frame
            if (_frames.Any() && !_frames.Last().IsFrameDone())
            {
                _frames.Last().AddRolls(pins);
            }
            // Existing frame is done, so move to next frame
            else
            {
                // New frame to move is not last frame,
                // hence create a Frame obejct and add cuurent pins to the roll
                if (_frames.Count < Constants.MAX_FRAMES - 1)
                {
                    Frame frame = new Frame();
                    frame.AddRolls(pins);
                    _frames.Add(frame);
                }
                // We are on the second last frame and new frame to move is last frame,
                // hence create a LastFrame object and add current pins to the roll
                else
                {
                    LastFrame frame = new LastFrame();
                    frame.AddRolls(pins);
                    _frames.Add(frame);
                }
            }
        }

        public int GetScore()
        {
            // Returns the final score of the game.
            return UtilityFunctions.CalculateScore(_frames);
        }
    }
}
