// <copyright file="ParkingLotRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using ApplicationModelLayer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Parking Lot Repository.
    /// </summary>
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly ILogger<ParkingLotRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParkingLotRepository"/> class.
        /// </summary>
        /// <param name="configuration">Object Of Iconfiguration.</param>
        /// <param name="logger">Object Of Ilogger.</param>
        public ParkingLotRepository(IConfiguration configuration, ILogger<ParkingLotRepository> logger)
        {
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.connection = new SqlConnection(this.connectionString);
            this.logger = logger;
        }

        /// <summary>
        /// Method to add vehicle to Parking.
        /// </summary>
        /// <param name="vehicleDetails">Object of VehicleDetails Model.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> AddVehicleToParking(VehicleDetails vehicleDetails)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spPark", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleNumber", vehicleDetails.VehicleNumber);
                cmd.Parameters.AddWithValue("@ParkingType", vehicleDetails.ParkingType);
                cmd.Parameters.AddWithValue("@DriverType", vehicleDetails.DriverType);
                cmd.Parameters.AddWithValue("@VehicleType", vehicleDetails.VehicleType);
                this.connection.Open();
                var result = cmd.ExecuteNonQuery();
                this.connection.Close();
                if (result > 0)
                {
                    this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Parked SuccessFully.");
                    return this.FindVehicleByVehicleNumber(vehicleDetails.VehicleNumber);
                }

                return null;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Method to remove vehicle from Parking.
        /// </summary>
        /// <param name="slotNumber">Slot Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> UnParkVehicle(int slotNumber)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUnpark", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SlotNumber", slotNumber);
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Unparked With Number" + parking[0].VehicleNumber);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Find vehicle from Parking By Vehicle Number.
        /// </summary>
        /// <param name="vehicleNumber">Vehicle Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> FindVehicleByVehicleNumber(string vehicleNumber)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spFindVehicleByVehicleNumber", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VehicleNumber", vehicleNumber);
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Found With Number" + parking[0].VehicleNumber);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Find vehicle from Parking By slotNumber.
        /// </summary>
        /// <param name="slotNumber">Slot Number.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> FindVehicleBySlotNumber(int slotNumber)
        {
            List<Parking> parkedVehicleList = new List<Parking>();
            try
            {
                SqlCommand cmd = new SqlCommand("spFindVehicleBySlotId", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SlotId", slotNumber);
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Found On" + parking[0].SlotId + " Slot With Vehicle Number " + parking[0].VehicleNumber);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Get All Parked vehicle from Parking.
        /// </summary>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> GetAllParkedVehicles()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spGetAllParkedVehicles", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Found With Number" + parking[0].VehicleNumber);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Get All vehicle from Parking.
        /// </summary>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> GetAllVehicles()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spGetAllVehicles", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Found With Number" + parking[0].VehicleNumber);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Fetch Vehicles Data By Using Parking Id.
        /// </summary>
        /// <param name="parkingId">Parking Id.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> FindVehicleByParkingId(int parkingId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spFindVehicleByParkingId", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParkingId", parkingId);
                List<Parking> parking = this.FetchRecords(cmd);
                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Vehicle Found On ParkingId" + parking[0].ParkingId);
                return parking;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to Get All Empty Slots Parking.
        /// </summary>
        /// <returns>List Of Empty Parking Slot Numbers.</returns>
        public List<int> GetEmptySlotList()
        {
            List<int> emptySlotList = new List<int>();
            try
            {
                SqlCommand cmd = new SqlCommand("spGetReservedParkingSlots", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                this.connection.Open();
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        int slotId = Convert.ToInt32(result["SLOT_ID"]);
                        emptySlotList.Add(slotId);
                    }
                }

                this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Fetching List Of Empty Slots");
                return emptySlotList;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Delete Record By Using Parking Id.
        /// </summary>
        /// <param name="parkingId">parking id.</param>
        /// <returns>List Of Object Of Parking Models.</returns>
        public List<Parking> DeleteRecordByParkingId(int parkingId)
        {
            List<Parking> parking = this.FindVehicleByParkingId(parkingId);
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteRecordByParkingId", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParkingId", parkingId);
                this.connection.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    this.logger.LogDebug(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": " + parking[0].ParkingId + " Record Deleted Successfully ");
                    return parking;
                }

                return null;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private List<Parking> FetchRecords(SqlCommand cmd)
        {
            List<Parking> parkedVehicleList = new List<Parking>();
            try
            {
                this.connection.Open();
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Parking parking = new Parking();
                        parking.ParkingId = Convert.ToInt32(result["PARKING_ID"]);
                        parking.ParkingType = Convert.ToInt32(result["PARKING_TYPE"]);
                        parking.VehicleNumber = result["VEHICLE_NUMBER"].ToString();
                        parking.VehicleType = Convert.ToInt32(result["VEHICLE_TYPE"]);
                        parking.DriverType = Convert.ToInt32(result["DRIVER_TYPE"]);
                        parking.EntryTime = result["ENTRY_TIME"].ToString();
                        parking.ExitTime = (result["EXIT_TIME"] is null) ? "NULL" : result["EXIT_TIME"].ToString();
                        parking.ParkingCharge = Convert.ToInt32(result["CHARGES"]);
                        parking.SlotId = Convert.ToInt32(result["SLOT_ID"]);
                        parkedVehicleList.Add(parking);
                    }
                }

                this.connection.Close();
                return parkedVehicleList;
            }
            catch (Exception e)
            {
                this.logger.LogError(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Exception : " + e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
