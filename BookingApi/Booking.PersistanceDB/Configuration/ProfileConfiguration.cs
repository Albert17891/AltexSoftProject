using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.PersistanceDB.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => new { x.Email }).IsUnique();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Photo).IsUnicode(false);
            builder.HasOne<Apartment>(x => x.Apartment).WithOne(x => x.Profile).HasForeignKey<Apartment>(x => x.HostId);
            builder.HasMany<Order>(x => x.Order).WithOne(x => x.Profile)
                .HasForeignKey(x => x.HostId);

        }
    }
}
