using Booking.Services.Abstractions;
using Booking.Services.Models;
using BookingApi.Models.DTO;
using BookingApi.Models.Request;
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
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;
        private readonly ILogger<SearchController> _logger;

        public SearchController(ISearchService service,ILogger<SearchController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [EnableCors]
        [HttpPost] 
        public async Task<IActionResult> GetApartment(SearchRequest searchRequest)
        {
            
                if (searchRequest == null)
                    return BadRequest();

                var apartment = await _service.GetAllApartment(searchRequest.City, searchRequest.From, searchRequest.To);
                return Ok(apartment.Adapt<List<ApartmentDTO>>());      
            
        }

        [EnableCors]
        [Route("Booking")]
        [HttpPost]
        public async Task<IActionResult> Booking(OrderRequest orderRequest)
        {
           
                if (orderRequest == null)
                    return BadRequest();
                await _service.Booking(orderRequest.Adapt<OrderServiceModel>());
                return Ok();
            
        }
    }
}
