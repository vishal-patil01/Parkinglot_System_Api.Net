// <copyright file="PoliceController.cs" company="PlaceholderCompany">
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
    /// Controller for Police.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IPoliceService policeService;
        private readonly ILogger<PoliceController> logger;

        public PoliceController(IPoliceService policeService, ILogger<PoliceController> logger)
        {
            this.policeService = policeService;
            this.logger = logger;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult Park([FromBody] VehicleDetails vehicleDetails)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Park Api");
            List<Parking> parkingDetails = this.policeService.ParkVehicle(vehicleDetails);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingDetails));
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult Unpark(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Unpark Api");
            List<Parking> parkingDetails = this.policeService.UnParkVehicle(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", parkingDetails));
        }

        [Route("search/vehicleNumber")]
        [HttpGet]
        public ActionResult FindVehicleByVehicleNumber(string vehicleNumber)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By VehicleNumber Api");
            List<Parking> parkingDetails = this.policeService.FindVehicleByVehicleNumber(vehicleNumber);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", parkingDetails));
        }

        [Route("search/{slotId}")]
        [HttpGet]
        public ActionResult FindVehicleBySlotId(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By slotId Api");
            List<Parking> vehicleList = this.policeService.FindVehicleBySlotNumber(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", vehicleList));
        }
    }
}
