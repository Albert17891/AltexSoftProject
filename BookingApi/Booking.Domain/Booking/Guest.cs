using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Booking
{
    public class Guest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? Status { get; set; }//Status
    }
}
