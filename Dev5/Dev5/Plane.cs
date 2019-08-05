using System;

namespace Dev5
{
    /// <summary>
    /// Class for planes
    /// </summary>
    class Plane : IFlyable
    {
        public int FlySpeed { get; private set; }
        public int Acceleration { get; private set; }
        public int AccelerationFrequency { get; private set; }
        public Point StartPoint { get; private set; }
        public double Distance { get; private set; }
        public event EventHandler<ObjectFlewInEventArgs> ObjectFlewIn;

        /// <summary>
        /// Constructor initializes fields
        /// Start speed 200 km/h
        /// Acceleration 10 km/h every 10 km
        /// Starting point (0, 0, 0)
        /// </summary>
        public Plane()
        {
            this.FlySpeed = 200;
            this.Acceleration = 10;
            this.AccelerationFrequency = 10;
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
        public double GetFlyTime()
        {
            double flyTime = 0;
            double distance = this.Distance;

            for (; distance > this.AccelerationFrequency;)
            {
                flyTime += (double)this.AccelerationFrequency / this.FlySpeed;
                this.FlySpeed += this.Acceleration;
                distance -= this.AccelerationFrequency;
            }

            flyTime += distance / this.FlySpeed;
            this.FlySpeed += (int)(this.Acceleration * distance / this.AccelerationFrequency);

            return flyTime;
        }

        /// <summary>
        /// Returns object reference
        /// </summary>
        /// <returns>Object reference</returns>
        public object WhoAmI() => this;
    }
}