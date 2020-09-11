namespace ParkingLotApplication.Controllers
{
    using ApplicationModelLayer;
    using ApplicationServiceLayer;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/Login")]
        public IActionResult Login([FromBody] UserLogin user)
        {
            try
            {
                string Token = userService.Login(user);
                if (Token.Length > 3)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Token", Token));
                }
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Login Failed"));
            }
            catch (Exception e)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Login Failed"));
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] Users userDetails)
        {
            try
            {
                bool result = userService.AddUser(userDetails);
                if (result)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Token", result));
                }
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Token"));
            }
            catch (Exception e)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Token"));
            }
        }
    }
}
