// <copyright file="SecurityService.cs" company="PlaceholderCompany">
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
    public class SecurityService : ISecurityService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        private readonly IMSMQService mSMQService;

        public SecurityService(IParkingLotRepository parkingLotRepository, IMSMQService mSMQService)
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

        public List<Parking> ParkVehicle(VehicleDetails vehicleDetails)
        {
            List<Parking> parking = this.parkingLotRepository.AddVehicleToParking(vehicleDetails);
            if (parking != null)
            {
                this.mSMQService.AddToQueue("Security Parked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime);
            }

            return parking;
        }

        public List<Parking> UnParkVehicle(int slotId)
        {
            List<Parking> parking = this.parkingLotRepository.UnParkVehicle(slotId);
            if (parking.Count != 0)
            {
                this.mSMQService.AddToQueue("Security Unparked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime + " And Customer Has To Pay Charges " + parking[0].ParkingCharge);
            }

            return parking;
        }
    }
}
