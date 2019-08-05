using System.Collections.Generic;

namespace Dev6
{
    /// <summary>
    /// The command to count brands.
    /// </summary>
    public class CommandCountBrands : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterBrands counter;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountBrands"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        public CommandCountBrands(CounterBrands receiver, List<VehicleInfoStruct> listOfVehicles)
        {
            this.counter = receiver;
            this.listOfVehicles = listOfVehicles;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public double Execute() => this.counter.CountBrands(this.listOfVehicles);
    }
}