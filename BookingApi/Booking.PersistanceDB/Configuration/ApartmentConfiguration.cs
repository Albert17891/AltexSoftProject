using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.PersistanceDB.Configuration
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HostId).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.NumbOfBeds).IsRequired();
            builder.Property(x => x.DistanceToCenter).IsRequired();
            builder.Property(x => x.From).IsRequired();
            builder.Property(x => x.To).IsRequired();
            builder.Property(x => x.Photo).IsUnicode();


        }
    }
}
