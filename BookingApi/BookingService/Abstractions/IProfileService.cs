using Booking.Services.Models;
using Booking.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Services.Abstractions
{
    public interface IProfileService
    {
        public Task<ProfileServiceModel> GetProfileInfo(int userId);
        public Task AddApartment(ApartmentServiceModel apartment);      
        public Task UpdateProfile(ProfileServiceModel profile);

        public Task RegisterUser(ProfileServiceModel user);

        public Task<UserIdWithTokenSerModel> AuthenticateUser(string email, string password);
    }
}
