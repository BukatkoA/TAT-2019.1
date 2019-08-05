using System;

namespace Dev5
{
    /// <summary>
    /// Class contains arguments for the ObjectFlewIn event
    /// </summary>
    class ObjectFlewInEventArgs : EventArgs
    {
        public double Distance { get; private set; }
        public double Time { get; private set; }
        public int Speed { get; private set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="distance">Distance of the flight</param>
        /// <param name="time">Time of the flight</param>
        /// <param name="speed">Final speed of the flight</param>
        public ObjectFlewInEventArgs(double distance, double time, int speed)
        {
            this.Distance = distance;
            this.Time = time;
            this.Speed = speed;
        }
    }
}