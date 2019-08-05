using System;
using System.Collections.Generic;

namespace Dev5
{
    /// <summary>
    /// Calculates flight time of different objects
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point creates 3 different IFlyable objects, adds subscribers to event
        /// </summary>
        static void Main()
        {
            try
            {
                var flyables = new List<IFlyable>() { new Bird(), new Plane(), new SpaceShip() };
                var targetPoint = new Point(100, 200, 800);
                var logger = new Logger();

                foreach (var flyable in flyables)
                {
                    flyable.ObjectFlewIn += logger.LogFlight;
                    flyable.FlyTo(targetPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}