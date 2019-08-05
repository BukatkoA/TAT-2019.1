using System;

namespace Dev5
{
    /// <summary>
    /// Interface for objects that can fly
    /// </summary>
    interface IFlyable
    {
        /// <summary>
        /// Event notifies that an object finished flight
        /// </summary>
        event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;

        /// <summary>
        /// Changes coordinates of object
        /// </summary>
        /// <param name="newPoint">New flight point</param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// Calculates time of flight
        /// </summary>
        /// <returns>Time of flight</returns>
        double GetFlyTime();

        /// <summary>
        /// Returns object reference
        /// </summary>
        /// <returns>Object reference</returns>
        object WhoAmI();
    }
}