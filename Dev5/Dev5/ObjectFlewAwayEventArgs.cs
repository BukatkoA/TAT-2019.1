using System;

namespace Dev5
{
    ///  <summary>
    ///  Class for an event that has some information.
    ///  </summary>
    public class ObjectFlewAwayEventArgs : EventArgs
    {
        public double Time { get; set; }
        public double Speed { get; set; }

        /// <summary>
        /// Constructor for ObjectFlewAwayEventArgs
        /// </summary>
        /// <param name="time">Time of flight</param>
        /// <param name="speed">Speed of flight</param>
        public ObjectFlewAwayEventArgs(double time, double speed)
        {
            Time = time;
            Speed = speed;
        }
    }
}