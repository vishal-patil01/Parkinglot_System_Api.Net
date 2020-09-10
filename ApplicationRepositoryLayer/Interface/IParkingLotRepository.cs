// <copyright file="IParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationRepositoryLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;

    /// <summary>
    /// Interface for Parking Lot Repository.
    /// </summary>
    public interface IParkingLotRepository
    {
        /// <summary>
        /// Method to add vehicle to Parking.
        /// </summary>
        /// <param name="vehicleDetails">Object of VehicleDetails Model.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        List<Parking> AddVehicleToParking(VehicleDetails vehicleDetails);

        /// <summary>
        /// Fetch Vehicles Data By Using Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        List<Parking> FindVehicleByParkingId(int parkingId);

        /// <summary>
        /// Method to remove vehicle from Parking.
        /// </summary>
        /// <param name="slotId">Slot Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        List<Parking> UnParkVehicle(int slotId);

        /// <summary>
        /// Method to Find vehicle from Parking By Vehicle Number.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> FindVehicleByVehicleNumber(string vehicleNumber);

        /// <summary>
        /// Method to Find vehicle from Parking By slotNumber.
        /// </summary>
        /// <param name="slotNumber">Slot Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> FindVehicleBySlotNumber(int slotNumber);

        /// <summary>
        /// Method to Get All Parked vehicle from Parking.
        /// </summary>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> GetAllParkedVehicles();

        /// <summary>
        /// Method to Get All vehicle from Parking.
        /// </summary>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> GetAllVehicles();

        /// <summary>
        /// Method to Get All Empty Slots Parking.
        /// </summary>
        /// <returns>List Of Empty Parking Slot Numbers.</returns>
        public List<int> GetEmptySlotList();

        /// <summary>
        /// Delete Record By Using Parking Id.
        /// </summary>
        /// <param name="parkingId">parking id.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> DeleteRecordByParkingId(int parkingId);
    }
}
