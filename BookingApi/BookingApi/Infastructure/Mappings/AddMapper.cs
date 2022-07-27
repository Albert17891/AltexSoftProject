using Booking.Domain.Booking;
using Booking.Services.Models;
using BookingApi.Models.DTO;
using BookingApi.Models.Request;
using Mapster;

namespace BookingApi.Infastructure.Mappings
{
    public static class AddMapper
    {
        public static void AddMapping(this IServiceCollection services)
        {
            TypeAdapterConfig<Apartment, ApartmentServiceModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<ApartmentServiceModel, ApartmentDTO>
               .NewConfig()
               .TwoWays();

            TypeAdapterConfig<OrderRequest, OrderServiceModel>
             .NewConfig()
             .TwoWays();
            TypeAdapterConfig<OrderServiceModel, Order>
             .NewConfig()
             .TwoWays();





            TypeAdapterConfig<BookingServiceModel, Order>
           .NewConfig()
           .Map(dest => dest.City, src => src.City)
           .Map(dest => dest.From, src => src.From)
           .Map(dest => dest.To, src => src.To)
            .PreserveReference(true)
           .TwoWays();


            TypeAdapterConfig<GuestServiceModel, Order>
             .NewConfig()
             .Map(dest => dest.Id, src => src.Id)
             .Map(dest => dest.FirstName, src => src.FirstName)
             .Map(dest => dest.LastName, src => src.LastName)
             .Map(dest => dest.From, src => src.From)
             .Map(dest => dest.To, src => src.To)
             .PreserveReference(true)
             .TwoWays();



            TypeAdapterConfig<Profile, ProfileServiceModel>
              .NewConfig()
              .PreserveReference(true);




            TypeAdapterConfig<GuestServiceModel, GuestDTO>
              .NewConfig()
              .TwoWays();

            TypeAdapterConfig<BookingServiceModel, BookingDTO>
              .NewConfig()
              .TwoWays();

            TypeAdapterConfig<BookingWithApartment, BookingWithApartmentDTO>
              .NewConfig()
              .TwoWays();



            TypeAdapterConfig<ProfileServiceModel, ProfileDTO>
           .NewConfig()
           .TwoWays();


        }

    }
}
