using Booking.Data;
using Booking.Domain.Booking;
using Booking.Services.Abstractions;
using Booking.Services.Exceptions;
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
        private readonly IOrderRepository _orderRepository;

        public ProfileService(IProfileRepository repository, ISearchRepository searchRepo, IJWTService jwtService,IOrderRepository orderRepository)
        {
            _repository = repository;
            _searchRepo = searchRepo;
            _jwtService = jwtService;
            _orderRepository = orderRepository;

        }

        public async Task AddApartment(ApartmentServiceModel apartment)
        {
            await _searchRepo.AddApartment(apartment.Adapt<Apartment>());
        }



        public async Task<ProfileServiceModel> GetProfileInfo(int userId)
        {
            var profileInfo = await _repository.GetProfileInfo(userId);//Get Profile
            if (profileInfo == null)
                throw new ObjectNotFoundException("Profile Not Found");

            var booking = await _orderRepository.GetBookings(userId);//Get Bookings

            ProfileServiceModel profile = new ProfileServiceModel
            {
                UserId = profileInfo.UserId,
                FirstName = profileInfo.FirstName,
                LastName = profileInfo.LastName,
                Email = profileInfo.Email,
                Description = profileInfo.Description,
                Photo = profileInfo.Photo,
                Apartment = profileInfo.Apartment.Adapt<ApartmentServiceModel>(),
                 Bookings=booking.Adapt<List<BookingServiceModel>>(),
                Guests = profileInfo.Order.Adapt<List<GuestServiceModel>>(),
            };

            return profile;
        }

        public async Task UpdateProfile(ProfileServiceModel profile)
        {
            await _repository.UpdateProfile(profile.Adapt<Profile>());
        }

        public async Task RegisterUser(ProfileServiceModel user)
        {
            await _repository.AddUser(user.Adapt<Profile>());
        }

        public async Task<UserIdWithTokenSerModel> AuthenticateUser(string email, string password)
        {
            var user = await _repository.GetUser(email, password);
            if (user == null)
                throw new ObjectNotFoundException("Cannot Find User");
            var token = _jwtService.GenerateSecurityToken(user.Email);
            UserIdWithTokenSerModel userIdWithToken = new UserIdWithTokenSerModel() { UserId = user.UserId, Token = token };
            return userIdWithToken;
        }
    }
}
