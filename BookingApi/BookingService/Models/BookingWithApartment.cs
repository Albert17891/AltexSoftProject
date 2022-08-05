using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Models
{
    public class BookingWithApartment
    {
        public int CustomerId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? Status { get; set; }
        public ApartmentServiceModel? Apartment { get; set; }
    }
}
