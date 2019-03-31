namespace Dev5
{
    /// <summary>
    /// Object Plane - has speed +10 km/hour each 10 km of fly starting from 200 km/hour.
    /// </summary>
    public class Plane : FlyingObject
    {
        // Plane speed is measured in km/hour
        const double StartingPlaneSpeed = 200;
        const double speedIncrease = 10;
        const double distanceOfChangeSpeed = 10;

        /// <summary>
        /// Constructor of Plane.
        /// </summary>
        public Plane() : base(StartingPlaneSpeed) { }

        /// <summary>
        /// Overrides base class.
        /// </summary>
        /// <param name="newPoint">New point to fly to</param>
        public override void FlyTo(Point newPoint)
        {
            base.FlyTo(newPoint);
            Speed = StartingPlaneSpeed;
        }

        /// <summary>
        /// Calculates object flight time.
        /// </summary>
        /// <returns>Flight time</returns>
        public override double GetFlyTime()
        {
            double distance = StartPoint.GetDistanceToPoint(FinishPoint);
            double flightTime = 0;

            while (distance > 0)
            {
                if (distance > distanceOfChangeSpeed)
                {
                    flightTime += distanceOfChangeSpeed / Speed;
                    distance -= distanceOfChangeSpeed;
                    Speed += speedIncrease;
                }
                else
                {
                    flightTime += distance / Speed;
                    break;
                }
            }

            return flightTime;
        }
    }
}