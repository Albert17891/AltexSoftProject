using Booking.Data;
using Booking.DataEF;
using Booking.PersistanceDB.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Infastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepoService(this IServiceCollection services)
        {
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();           
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<DbContext, BookingContext>();
        }
    }
}
