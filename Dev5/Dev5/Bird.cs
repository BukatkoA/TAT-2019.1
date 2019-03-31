using System;

namespace Dev5
{
    /// <summary>
    /// Object Bird - random speed up to 20 km/h
    /// </summary>
    public class Bird : FlyingObject
    {
        /// <summary>
        /// Constuctor of Bird, initializes random speed 1-20 km/h.
        /// </summary>
        public Bird() : base(new Random().Next(1, 20)) { }
    }
}