using Booking.Services.Abstractions;
using BookingApi.Models.DTO;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _service;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService service, ILogger<BookingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors]

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetBookings(int customerId)
        {

            var bookings = await _service.GetAllBooking(customerId);

            _logger.LogInformation("GetBookings successfully");
            return Ok(bookings.Adapt<List<BookingWithApartmentDTO>>());
        }
    }
}
