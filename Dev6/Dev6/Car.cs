using System;

namespace Dev6
{
    /// <summary>
    /// Class of car
    /// </summary>
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="brand">Brand of the car</param>
        /// <param name="model">Model of the car</param>
        /// <param name="count">Count of the car</param>
        /// <param name="price">Price of the car</param>
        public Car(string brand, string model, int count, int price)
        {
            this.Brand = brand != string.Empty ? brand.ToLower() : throw new Exception("Error. Brand shouldn't be empty");
            this.Model = model != string.Empty ? model.ToLower() : throw new Exception("Error. Model shouldn't be empty");
            this.Count = count >= 0 ? count : throw new Exception("Error. Count should be non-negative");
            this.Price = price >= 0 ? price : throw new Exception("Error. Price should be non-negative");
        }
    }
}