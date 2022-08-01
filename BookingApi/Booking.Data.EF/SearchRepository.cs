using Booking.Data;
using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataEF
{
    public class SearchRepository : ISearchRepository
    {

        private readonly IBaseRepository<Apartment> _repository;

        public SearchRepository(IBaseRepository<Apartment> repository)
        {
            _repository = repository;
        }
        public async Task<List<Apartment>> GetApartmentWithCity(string city, DateTime From, DateTime To)
        {
            var cities = await _repository.Table.Where(x => x.City == city).ToListAsync();
            foreach (var city2 in cities)
            {
                if (city2.From.Date <= From.Date && city2.To.Date >= To.Date)
                    city2.IsAvailable = true;
                else
                    city2.IsAvailable = false;
            }
            return cities;
        }

        public async Task AddApartment(Apartment apartment)
        {
            await _repository.AddAsync(apartment);
        }

        public async Task<Apartment?> GetApartmentWithHostId(int hostId)
        {
            return await _repository.Table.Where(x => x.HostId == hostId).SingleOrDefaultAsync();
        }
    }
}
