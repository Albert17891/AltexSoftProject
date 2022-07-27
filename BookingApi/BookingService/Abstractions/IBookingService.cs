using Booking.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Abstractions
{
    public interface IBookingService
    {
        public Task<List<BookingWithApartment>> GetAllBooking(int customerId);
    }
}
