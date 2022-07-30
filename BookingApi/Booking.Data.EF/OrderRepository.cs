using Booking.Data;
using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataEF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IBaseRepository<Order> _repository;

        public OrderRepository(IBaseRepository<Order> repository)
        {
            _repository = repository;
        }
        public async Task Booking(Order order)
        {
            await _repository.AddAsync(order);
        }

        public async Task<List<Order>> GetBookings(int customerId)
        {
            return await _repository.Table.Where(x => x.CustomerId == customerId).ToListAsync();

        }

        public async Task<List<Order>> GetGuests(int hostId)
        {
            return await _repository.Table.Where(x => x.HostId == hostId).ToListAsync();
        }

        public async Task UpdateOrder(Guest guest)
        {


            var order = await _repository.GetById(guest.Id);

            if (order != null)
            {
                order.Status = guest.Status;
                await _repository.Update(order);
            }
            else
                throw new NullReferenceException();
        }
    }
}
