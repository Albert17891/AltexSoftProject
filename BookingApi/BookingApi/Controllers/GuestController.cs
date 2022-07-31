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
        private readonly ILogger<GuestController> _logger;

        public GuestController(IGuestService service,ILogger<GuestController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors]
        //[Route("GetGuest")]
        [HttpGet("{hostId}")]
        public async Task<IActionResult> GetGuest(int hostId)
        {
            try
            {
                var guests = await _service.GetGuests(hostId);
                return Ok(guests.Adapt<List<GuestDTO>>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new  Exception();
            }
            
        }

        [EnableCors]
        //  [Route("UpdateGuest")]
        [HttpPut]
        public async Task<IActionResult> UpdateGuest(GuestDTO guest)
        {
            try
            {
                await _service.UpdateGuest(guest.Adapt<GuestServiceModel>());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
            
        }

       
    }
}
              