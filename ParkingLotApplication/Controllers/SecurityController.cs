// <copyright file="SecurityController.cs" company="PlaceholderCompany">
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
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService securityService;
        private readonly ILogger<SecurityController> logger;

        public SecurityController(ISecurityService securityService, ILogger<SecurityController> logger)
        {
            this.securityService = securityService;
            this.logger = logger;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult Park([FromBody] VehicleDetails vehicleDetails)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Park Api");
            List<Parking> parkingDetails = this.securityService.ParkVehicle(vehicleDetails);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingDetails));
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult Unpark(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Unpark Api");
            List<Parking> parkingDetails = this.securityService.UnParkVehicle(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", parkingDetails));
        }

        [Route("search/vehicleNumber")]
        [HttpGet]
        public ActionResult FindVehicleByVehicleNumber(string vehicleNumber)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By VehicleNumber Api");
            List<Parking> parkingDetails = this.securityService.FindVehicleByVehicleNumber(vehicleNumber);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", parkingDetails));
        }

        [Route("search/{slotId}")]
        [HttpGet]
        public ActionResult FindVehicleBySlotId(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Search By slotId Api");
            List<Parking> vehicleList = this.securityService.FindVehicleBySlotNumber(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Found Successfully", vehicleList));
        }
    }
}
