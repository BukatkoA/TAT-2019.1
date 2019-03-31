using System;

namespace Dev5
{
    /// <summary>
    /// Interface for flying object
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Event that notifies it's subscribers that an object changed it's location
        /// </summary>
        event EventHandler<ObjectFlewAwayEventArgs> ObjectFlewAway;

        /// <summary>
        /// Changes current coordinates of the object
        /// </summary>
        /// <param name="newPoint">New point to fly to</param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// Calculates time that took the object to fly
        /// </summary>
        /// <returns>Time of the flight</returns>
        double GetFlyTime();

        /// <summary>
        /// Returns a reference to a particular object
        /// </summary>
        /// <returns>Reference to the particular object</returns>
        IFlyable WhoAmI();
    }
}