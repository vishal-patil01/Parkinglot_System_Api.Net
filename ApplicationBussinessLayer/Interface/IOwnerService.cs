// <copyright file="IOwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Owner service.
    /// </summary>
    public interface IOwnerService
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

        /// <summary>
        /// Method to Find All Vehicle from Parking.
        /// </summary>
        /// <returns></returns>
        public List<Parking> GetAllVehicles();

        /// <summary>
        /// Method to Find Vehicle Record By Parking Id.
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns></returns>
        List<Parking> FindVehicleByParkingId(int parkingId);

        /// <summary>
        /// Method to Find All Parked Vehicle from Parking.
        /// </summary>
        /// <returns></returns>
        public List<Parking> GetAllParkedVehicles();

        /// <summary>
        /// Method to Get All Empty Slots Parking.
        /// </summary>
        /// <returns></returns>
        public List<int> GetEmptySlotList();

        /// <summary>
        /// Delete Record By Using Parking Id.
        /// </summary>
        /// <param name="parkingId">parking id.</param>
        /// <returns>Parking Object.</returns>
        public List<Parking> DeleteRecordByParkingId(int parkingId);
    }
}
