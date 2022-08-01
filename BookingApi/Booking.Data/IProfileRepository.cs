using Booking.Domain.Booking;

namespace Booking.Data
{
    public interface IProfileRepository
    {

        public Task<Profile> GetProfileInfo(int userId);

        public Task UpdateProfile(Profile profile);

        public Task<Profile?> GetUser(string email, string password);

        public Task AddUser(Profile user);

    }
}
