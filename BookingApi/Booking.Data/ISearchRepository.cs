using Booking.Domain.Booking;

namespace Booking.Data
{
    public interface ISearchRepository
    {
        public Task<List<Apartment>> GetApartmentWithCity(string city, DateTime From, DateTime To);

        public Task AddApartment(Apartment apartment);

        public Task<Apartment> GetApartmentWithHostId(int hostId);
    }
}
