using System.Collections.Generic;

namespace Dev6
{
    /// <summary>
    /// The command to count average price.
    /// </summary>
    public class CommandCountAveragePrice : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterAveragePrice counter;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountAveragePrice"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        public CommandCountAveragePrice(CounterAveragePrice receiver, List<VehicleInfoStruct> listOfVehicles)
        {
            this.counter = receiver;
            this.listOfVehicles = listOfVehicles;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public double Execute() => this.counter.CountAveragePrice(this.listOfVehicles);
    }
}