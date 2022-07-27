using Booking.Data;
using Booking.Services.Abstractions;
using Booking.Services.Models;
using Mapster;

namespace Booking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IOrderRepository _repository;
        private readonly ISearchRepository _searchRepository;

        public BookingService(IOrderRepository repository,ISearchRepository searchRepository)
        {
            _repository = repository;
            _searchRepository = searchRepository;
        }
        public async Task<List<BookingWithApartment>> GetAllBooking(int customerId)
        {
            var bookings = await _repository.GetBookings(customerId);

            ApartmentServiceModel model = null;
            List<BookingWithApartment> bookingModel = null;

            foreach (var item in bookings)
            {
                var apartment = await _searchRepository.GetApartmentWithHostId(item.HostId);
                model = new ApartmentServiceModel()
                {
                    
                        City=apartment.City,
                        Address=apartment.Address,
                        NumbOfBeds=apartment.NumbOfBeds,
                        Photo=apartment.Photo,
                        DistanceToCenter=apartment.DistanceToCenter,
                        Description=apartment.Description,
                        From=apartment.From,
                        To=apartment.To
                    
                };

                bookingModel = new List<BookingWithApartment>()
                {
                   new BookingWithApartment()
                   {
                       From=item.From,
                       To=item.To,
                       Status=item.Status,
                       Apartment=model
                   }
                };
            }

            return  bookingModel;
                 
        }
    }
}
