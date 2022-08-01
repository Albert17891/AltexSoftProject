using Booking.Services.Abstractions;
using Booking.Services.Models;
using Booking.Services.Models.Users;
using BookingApi.Models.Request;
using Mapster;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IProfileService _service;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IProfileService service,ILogger<AccountController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [EnableCors]
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginRequest loginRequest)
        {           
                var userIdWithToken = await _service.AuthenticateUser(loginRequest.Email, loginRequest.Password);
                if (userIdWithToken == null)
                    return BadRequest("Account with this Email or Password does not exist");

                return Ok(userIdWithToken);         
           
        }

        [EnableCors]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterRequest registerRequest)
        {
            await _service.RegisterUser(registerRequest.Adapt<ProfileServiceModel>());

            return Ok();

        }
    }
}
