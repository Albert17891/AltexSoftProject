using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;

namespace Booking.PersistanceDB.Context
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> opt) : base(opt)
        {

        }

        public DbSet<Apartment>? Apartments { get; set; }
        public DbSet<Order>? Orders { get; set; }

        public DbSet<Profile>? Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(BookingContext).Assembly);
        }

    }


}
