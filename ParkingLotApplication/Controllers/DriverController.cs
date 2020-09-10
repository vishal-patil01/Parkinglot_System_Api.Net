// <copyright file="DriverController.cs" company="PlaceholderCompany">
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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly ILogger<DriverController> logger;

        public DriverController(IDriverService driverService, ILogger<DriverController> logger)
        {
            this.driverService = driverService;
            this.logger = logger;
        }

        [Route("park")]
        [HttpPost]
        public ActionResult Park([FromBody] VehicleDetails vehicleDetails)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Park Api");
            List<Parking> parkingDetails = this.driverService.ParkVehicle(vehicleDetails);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Parked Successfully", parkingDetails));
        }

        [Route("unpark")]
        [HttpPut]
        public ActionResult Unpark(int slotId)
        {
            this.logger.LogInformation(this.GetType().Name + " : " + System.Reflection.MethodBase.GetCurrentMethod() + ": Accessed Unpark Api");
            List<Parking> parkingDetails = this.driverService.UnParkVehicle(slotId);
            return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Vehicle Unparked Successfully", parkingDetails));
        }
    }
}
