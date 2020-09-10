// <copyright file="IDriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Owner service.
    /// </summary>
    public interface IDriverService
    {
        /// <summary>
        /// Method to add vehicle to Parking.
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        List<Parking> ParkVehicle(VehicleDetails parking);

        /// <summary>
        /// Method to remove vehicle from Parking.
        /// </summary>
        /// <param name="slotId"></param>
        /// <returns></returns>
        List<Parking> UnParkVehicle(int slotId);

        /// <summary>
        /// Method to Find vehicle from Parking By Vehicle Number.
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public List<Parking> FindVehicleByVehicleNumber(string vehicleNumber);

        /// <summary>
        /// Method to Find vehicle from Parking By slotNumber.
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <returns></returns>
        public List<Parking> FindVehicleBySlotNumber(int slotNumber);
    }
}
