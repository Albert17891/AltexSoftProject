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
        private readonly ISearchRepository _searchRepository;

        public GuestService(IOrderRepository repository,ISearchRepository searchRepository)
        {
            _repository = repository;
            _searchRepository = searchRepository;
        }       

        public async Task<List<GuestServiceModel>> GetGuests(int hostId)
        {
            var guests = await _repository.GetGuests(hostId);

            if (guests.Count > 0)
            {
                var apartment = await _searchRepository.GetApartmentWithHostId(hostId);
                var guestService = guests.Adapt<List<GuestServiceModel>>();

                foreach (var item in guestService)
                {
                    item.Photo = apartment.Photo;
                }
                return guestService;
            }              
            
           

            return guests.Adapt<List<GuestServiceModel>>();

        }

        public  async Task UpdateGuest(GuestServiceModel guest)
        {
          await  _repository.UpdateOrder(guest.Adapt<Guest>());
        }
    }
}
