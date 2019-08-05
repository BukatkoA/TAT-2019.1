using System;

namespace Dev5
{
    /// <summary>
    /// Object Bird - random speed up to 20 km/h
    /// </summary>
    class Bird : IFlyable
    {
        public int FlySpeed { get; private set; }
        public Point StartPoint { get; private set; }
        public double Distance { get; private set; }
        public event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;
        private readonly int _minSpeed = 1;
        private readonly int _maxSpeed = 20;

        /// <summary>
        /// Constructor initializes fields
        /// Starting point (0, 0, 0)
        /// </summary>
        public Bird()
        {
            this.FlySpeed = new Random().Next(this._minSpeed, this._maxSpeed);
            this.StartPoint = new Point();
        }

        /// <summary>
        /// Changes coordinates of object
        /// </summary>
        /// <param name="newPoint">New flight point</param>
        public void FlyTo(Point newPoint)
        {
            if (!this.StartPoint.Equals(newPoint))
            {
                this.Distance = this.StartPoint.GetDistance(newPoint);
                this.StartPoint = newPoint;
                this.ObjectFlewIn?.Invoke(this.WhoAmI(), new ObjectFlewInEventArgs(this.Distance, this.GetFlyTime(), this.FlySpeed));
                this.Distance = 0;
            }
        }

        /// <summary>
        /// Calculates time of flight
        /// </summary>
        /// <returns>Time of flight</returns>
        public double GetFlyTime() => this.Distance / this.FlySpeed;

        /// <summary>
        /// Returns object reference
        /// </summary>
        /// <returns>Object reference</returns>
        public object WhoAmI() => this;
    }
}