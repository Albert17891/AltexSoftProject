using Booking.Data;
using Booking.Domain.Booking;
using Booking.Services.Abstractions;
using Booking.Services.Models;
using Booking.Services.Models.Users;
using Mapster;

namespace Booking.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly ISearchRepository _searchRepo;
        private readonly IJWTService _jwtService;


        public ProfileService(IProfileRepository repository, ISearchRepository searchRepo, IJWTService jwtService)
        {
            _repository = repository;
            _searchRepo = searchRepo;
            _jwtService = jwtService;
        }

        public async Task AddApartment(ApartmentServiceModel apartment)
        {
            await _searchRepo.AddApartment(apartment.Adapt<Apartment>());
        }



        public async Task<List<ProfileServiceModel>> GetProfileInfo(int userId)
        {
            var profileInfo = await _repository.GetProfileInfo(userId);

            List<ProfileServiceModel> models = null;

            foreach (var item in profileInfo)
            {
                models = new List<ProfileServiceModel>()
                 {
                   new ProfileServiceModel
                   {                     
                       UserId=item.UserId,
                       FirstName=item.FirstName,
                       LastName=item.LastName,
                       Email=item.Email,
                       Description=item.Description,
                       Photo=item.Photo,
                       Apartment=item.Apartment.Adapt<ApartmentServiceModel>(),
                       Bookings=item.Order.Adapt<List<BookingServiceModel>>(),
                       Guests=item.Order.Adapt<List<GuestServiceModel>>(),
                   }
                 };
            }


            return models;
        }

        public async Task UpdateProfile(ProfileServiceModel profile)
        {
            await _repository.AddProfile(profile.Adapt<Profile>());
        }

        public async Task RegisterUser(ProfileServiceModel user)
        {
            await _repository.AddUser(user.Adapt<Profile>());
        }

        public async Task<UserIdWithTokenSerModel> AuthenticateUser(string email, string password)
        {
            var user = await _repository.GetUser(email, password);
            if (user == null)
                throw new Exception();
            var token = _jwtService.GenerateSecurityToken(user.Email);
            UserIdWithTokenSerModel userIdWithToken = new UserIdWithTokenSerModel() { UserId = user.UserId, Token = token };
            return userIdWithToken;
        }
    }
}
