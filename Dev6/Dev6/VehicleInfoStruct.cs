namespace Dev6
{
    /// <summary>
    /// Struct for vehicle information.
    /// </summary>
    public struct VehicleInfoStruct
    {
        /// <summary>
        /// Brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Model of the brand.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Quantity of vehicles of this model.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of an individual vehicle
        /// </summary>
        public int Price { get; set; }
    }
}