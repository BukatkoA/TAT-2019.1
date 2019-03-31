namespace Dev5
{
    /// <summary>
    /// Object SpaceShip - constant speed 8000 km/sec
    /// </summary>
    public class SpaceShip : FlyingObject
    {
        /// <summary>
        /// Constructor of SpaceShip.
        /// The speed of the spaceship is 8000 km/sec = 28.8E+6 km/hour.
        /// </summary>
        public SpaceShip() : base(28.8E+6) { }
    }
}