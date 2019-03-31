using System;

namespace Dev5
{
    /// <summary>
    /// Base abstract class of flying objects.
    /// </summary>
    public abstract class FlyingObject : IFlyable
    {
        public event EventHandler<ObjectFlewAwayEventArgs> ObjectFlewAway;
        protected double Speed { get; set; }
        protected Point StartPoint { get; set; }
        protected Point FinishPoint { get; set; }

        /// <summary>
        /// Constuctor of flying object.
        /// </summary>
        public FlyingObject(double speed) => Speed = speed;

        /// <summary>
        /// Interface method implementation.
        /// </summary>
        /// <param name="newPoint">New point to fly to</param>
        virtual public void FlyTo(Point newPoint)
        {
            FinishPoint = newPoint;
            ObjectFlewAway?.Invoke(WhoAmI(), new ObjectFlewAwayEventArgs(GetFlyTime(), Speed));
            StartPoint = FinishPoint;
        }

        /// <summary>
        /// Interface method implementation.
        /// </summary>
        /// <returns this>Object reference</returns>
        public IFlyable WhoAmI() => this;

        /// <summary>
        /// Interface method implementation.
        /// </summary>
        /// <returns>Time of flight</returns>
        virtual public double GetFlyTime() => StartPoint.GetDistanceToPoint(FinishPoint) / Speed;
    }
}