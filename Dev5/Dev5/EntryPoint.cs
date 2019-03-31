using System;
using System.Collections.Generic;

namespace Dev5
{
    /// <summary>
    /// Creates flying objects for flight to a certain point.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program.
        /// Creates flying objects for flight to point.
        /// </summary>
        /// <returns 0>Normal start of program</returns>
        /// <returns 1>The program has errors</returns>
        static int Main(string[] args)
        {
            try
            {
                var flyables = new List<IFlyable> {new Bird(), new Plane(), new SpaceShip()};

                foreach (var flyable in flyables)
                {
                    // Add subscriber to the event
                    flyable.ObjectFlewAway += GetFlyTime;
                    flyable.FlyTo(new Point(100, 200, 800));
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                return 1;
            }
        }

        /// <summary>
        /// Subscriber to the ObjectFlewAway Event. Receives and displays time of the flight.
        /// </summary>
        /// <param name="obj">Object that flew to a new point</param>
        /// <param name="time">Time of the flight</param>
        private static void GetFlyTime(object obj, ObjectFlewAwayEventArgs e)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(e.Time * 3600, 3)} seconds, reaching {e.Speed / 3600} km/s"
                : $"{Math.Round(e.Time, 3)} hours, reaching {e.Speed} km/h");
        }
    }
}