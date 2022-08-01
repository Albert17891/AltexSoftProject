using Booking.Data;
using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataEF
{
    public class ProfileRepository : IProfileRepository
    {
        private IBaseRepository<Profile> _repository;

        public ProfileRepository(IBaseRepository<Profile> repository)
        {
            _repository = repository;
        }

        public async Task UpdateProfile(Profile profile)
        {

            var result = await _repository.Table.SingleOrDefaultAsync(x => x.UserId == profile.UserId);
            if (result != null)

            {
                result.FirstName = profile.FirstName;
                result.LastName = profile.LastName;
                result.Description = profile.Description;
                result.Photo = profile.Photo;
                await _repository.Update(result);
            }
            else
                throw new NullReferenceException();

        }

        public async Task AddUser(Profile user)
        {
            await _repository.AddAsync(user);
        }

        public async Task<Profile> GetProfileInfo(int userId)
        {
            var profile = await _repository.Table.Where(x => x.UserId == userId)
                .Include(x => x.Apartment)
                .Include(x => x.Order).SingleOrDefaultAsync();
            return profile;
        }
                                                                                                                          
        public async Task<Profile?> GetUser(string email, string password)
        {
            return await _repository.Table.SingleOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
