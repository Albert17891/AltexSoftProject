using Booking.Services.Abstractions;
using Booking.Services.Models;
using BookingApi.Models.DTO;
using BookingApi.Models.Request;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service;

        public ProfileController(IProfileService service)
        {
            _service = service;
        }

        [EnableCors]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var result = await _service.GetProfileInfo(userId);
            return Ok(result.Adapt<List<ProfileDTO>>());
        }


        [EnableCors]
        [Route("AddApartment")]
        [HttpPost]
        public async Task<IActionResult> AddApartment(ApartmentRequest apartment)
        {
            if (apartment == null)
                return BadRequest();
            await _service.AddApartment(apartment.Adapt<ApartmentServiceModel>());
            return Ok();
        }

        [EnableCors]
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(ProfileRequest profile)
        {
            if (profile == null)
                return BadRequest();
            await _service.UpdateProfile(profile.Adapt<ProfileServiceModel>());
            return Ok();
        }
    }
}
