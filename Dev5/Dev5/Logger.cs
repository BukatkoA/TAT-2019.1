using System;

namespace Dev5
{
    /// <summary>
    /// Contains methods for logging events
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Subscriber to the ObjectFlewIn event
        /// Receives and displays distance, time and speed of the flight
        /// </summary>
        /// <param name="obj">An object that flew in</param>
        /// <param name="e">Arguments of the flight from the event</param>
        public void LogFlight(object obj, ObjectFlewInEventArgs e)
        {
            if (obj is IFlyable)
            {
                //Time in hours * 3600 = time in seconds
                Console.WriteLine($"{obj.GetType().Name} flew {e.Distance:0.###} km in {e.Time * 3600:0.###} sec and reached a speed of {e.Speed:0.###} km/h");
            }
        }
    }
}