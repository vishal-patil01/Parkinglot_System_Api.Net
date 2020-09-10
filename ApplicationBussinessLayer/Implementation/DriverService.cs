// <copyright file="DriverService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;

    /// <summary>
    /// Service Layer for Owner.
    /// </summary>
    public class DriverService : IDriverService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        private readonly IMSMQService mSMQService;

        public DriverService(IParkingLotRepository parkingLotRepository, IMSMQService mSMQService)
        {
            this.parkingLotRepository = parkingLotRepository;
            this.mSMQService = mSMQService;
        }

        public List<Parking> FindVehicleBySlotNumber(int slotNumber)
        {
            return this.parkingLotRepository.FindVehicleBySlotNumber(slotNumber);
        }

        public List<Parking> FindVehicleByVehicleNumber(string vehicleNumber)
        {
            return this.parkingLotRepository.FindVehicleByVehicleNumber(vehicleNumber);
        }

        public List<Parking> ParkVehicle(VehicleDetails vehicle)
        {
            List<Parking> parking = this.parkingLotRepository.AddVehicleToParking(vehicle);
            if (parking.Count != 0)
            {
                this.mSMQService.AddToQueue("Driver Parked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime);
            }

            return parking;
        }

        public List<Parking> UnParkVehicle(int slotId)
        {
            List<Parking> parking = this.parkingLotRepository.UnParkVehicle(slotId);
            if (parking.Count != 0)
            {
                this.mSMQService.AddToQueue("Driver Unparked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime + " And Customer Has To Pay Charges " + parking[0].ParkingCharge);
            }

            return parking;
        }
    }
}
