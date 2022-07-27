using Booking.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Data
{
    public interface IOrderRepository
    {
        Task Booking(Order order);

        Task<List<Order>> GetGuests(int hostId);
        Task<List<Order>> GetBookings(int customerId);

        Task UpdateOrder(Guest guest);
    }
}
