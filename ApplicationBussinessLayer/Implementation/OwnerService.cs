// <copyright file="OwnerService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System.Collections.Generic;
    using System.Linq;
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;

    /// <summary>
    /// Service Layer for Owner.
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        private readonly IMSMQService mSMQService;

        public OwnerService(IParkingLotRepository parkingLotRepository, IMSMQService mSMQService)
        {
            this.parkingLotRepository = parkingLotRepository;
            this.mSMQService = mSMQService;
        }

        public List<Parking> DeleteRecordByParkingId(int parkingId)
        {
            return this.parkingLotRepository.DeleteRecordByParkingId(parkingId);
        }

        public List<Parking> FindVehicleByParkingId(int parkingId)
        {
            return this.parkingLotRepository.FindVehicleByParkingId(parkingId);
        }

        public List<Parking> FindVehicleBySlotNumber(int slotNumber)
        {
            return this.parkingLotRepository.FindVehicleBySlotNumber(slotNumber);
        }

        public List<Parking> FindVehicleByVehicleNumber(string vehicleNumber)
        {
            return this.parkingLotRepository.FindVehicleByVehicleNumber(vehicleNumber);
        }

        public List<Parking> GetAllParkedVehicles()
        {
            return this.parkingLotRepository.GetAllParkedVehicles();
        }

        public List<Parking> GetAllVehicles()
        {
            return this.parkingLotRepository.GetAllVehicles();
        }

        public List<int> GetEmptySlotList()
        {
            List<int> emptySlotLists = Enumerable.Range(1, 100).ToList();
            List<int> reservedSlotList = this.parkingLotRepository.GetEmptySlotList();
            for (int i = 1; i < reservedSlotList.Count(); i++)
            {
                emptySlotLists.Remove(reservedSlotList[i]);
            }

            return emptySlotLists;
        }

        public List<Parking> ParkVehicle(VehicleDetails vehicleDetails)
        {
            List<Parking> parking = this.parkingLotRepository.AddVehicleToParking(vehicleDetails);
            if (parking != null)
            {
                this.mSMQService.AddToQueue("Owner Parked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime);
            }

            return parking;
        }

        public List<Parking> UnParkVehicle(int slotId)
        {
            List<Parking> parking = this.parkingLotRepository.UnParkVehicle(slotId);
            if (parking.Count != 0)
            {
                this.mSMQService.AddToQueue("Owner Unparked Vehicle Having Number " + parking[0].VehicleNumber + " At Time " + parking[0].EntryTime + " And Customer Has To Pay Charges " + parking[0].ParkingCharge);
            }

            return parking;
        }
    }
}
