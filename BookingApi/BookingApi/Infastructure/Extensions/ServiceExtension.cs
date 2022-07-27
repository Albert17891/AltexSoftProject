using Booking.Services.Abstractions;
using Booking.Services.Implementations;

namespace BookingApi.Infastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IJWTService, JwtService>();           
            services.AddRepoService();
        }
    }
}
