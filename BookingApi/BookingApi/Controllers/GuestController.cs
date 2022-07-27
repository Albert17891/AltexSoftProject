using Booking.Services.Abstractions;
using Booking.Services.Models;
using BookingApi.Models.DTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _service;

        public GuestController(IGuestService service)
        {
            _service = service;
        }

        [EnableCors]
        //[Route("GetGuest")]
        [HttpGet("{hostId}")]
        public async Task<IActionResult> GetGuest(int hostId)
        {
            var guests =await _service.GetGuests(hostId);
            return Ok(guests.Adapt<List<GuestDTO>>());
        }

        [EnableCors]
        //  [Route("UpdateGuest")]
        [HttpPut]
        public async Task<IActionResult> UpdateGuest(GuestDTO guest)
        {
            await _service.UpdateGuest(guest.Adapt<GuestServiceModel>()) ;                       
            return Ok();  
        }

       
    }
}
              