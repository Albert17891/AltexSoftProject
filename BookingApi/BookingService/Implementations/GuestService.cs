using Booking.Data;
using Booking.Domain.Booking;
using Booking.Services.Abstractions;
using Booking.Services.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Implementations
{
    public class GuestService:IGuestService
    {
        private readonly IOrderRepository _repository;

        public GuestService(IOrderRepository repository)
        {
            _repository = repository;
        }       

        public async Task<List<GuestServiceModel>> GetGuests(int hostId)
        {
            var guests = await _repository.GetGuests(hostId);
            return guests.Adapt<List<GuestServiceModel>>();

        }

        public  async Task UpdateGuest(GuestServiceModel guest)
        {
          await  _repository.UpdateOrder(guest.Adapt<Guest>());
        }
    }
}
