// <copyright file="OwnerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ParkingLotApplication.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using ApplicationModelLayer;
    using ApplicationServiceLayer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Controller for Owner.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService ownerService;
        private readonly ILogger<OwnerController> logger;

        public OwnerController(IOwnerService ownerService, ILogger<OwnerController> logger)
        {
            this.ownerService = ownerService;
            this.logger = logger;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult Park([FromBody] VehicleDetails vehicleDetails)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Park Api");
            List<Parking> parkingDetails = this.ownerService.ParkVehicle(vehicleDetails);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingDetails));
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult Unpark(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Unpark Api");
            List<Parking> parkingDetails = this.ownerService.UnParkVehicle(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", parkingDetails));
        }

        [Route("search/parkingId")]
        [HttpGet]
        public ActionResult FindVehicleByParkinId(int parkingId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By ParkingId Api");
            List<Parking> parkingDetails = this.ownerService.FindVehicleByParkingId(parkingId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", parkingDetails));
        }

        [Route("search/vehicleNumber")]
        [HttpGet]
        public ActionResult FindVehicleByVehicleNumber(string vehicleNumber)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By VehicleNumber Api");
            List<Parking> parkingDetails = this.ownerService.FindVehicleByVehicleNumber(vehicleNumber);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", parkingDetails));
        }

        [Route("search/{slotId}")]
        [HttpGet]
        public ActionResult FindVehicleBySlotId(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By slotId Api");
            List<Parking> vehicleList = this.ownerService.FindVehicleBySlotNumber(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", vehicleList));
        }

        [Route("parked/vehicles")]
        [HttpGet]
        public ActionResult FindParkedVehicles()
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Get All Parked Vehicles Api");
            List<Parking> parkingDetails = this.ownerService.GetAllParkedVehicles();
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Data Fetched Successfully", parkingDetails));
        }

        [Route("all/vehicles")]
        [HttpGet]
        public ActionResult GetAllVehicles()
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Get All Vehicles Api");
            List<Parking> parkingDetails = this.ownerService.GetAllVehicles();
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Data Fetched Successfully", parkingDetails));
        }

        [Route("empty/slots")]
        [HttpGet]
        public ActionResult GetEmptySlotList()
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed GetAll Empty Parking Slots Api");
            List<int> emptySlotList = this.ownerService.GetEmptySlotList();
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Empty Slot List Fetched Successfully", emptySlotList));
        }

        [Route("{parkingId}")]
        [HttpDelete]
        public ActionResult DeleteByParkingId(int parkingId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Delete Record Api");
            List<Parking> parking = this.ownerService.DeleteRecordByParkingId(parkingId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Record Deleted Successfully", parking));
        }
    }
}
