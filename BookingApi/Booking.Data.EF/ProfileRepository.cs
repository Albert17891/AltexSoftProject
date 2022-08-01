using Booking.Data;
using Booking.Domain.Booking;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Booking.DataEF
{
    public class ProfileRepository : IProfileRepository
    {
        private IBaseRepository<Profile> _repository;

        const string SECRET_KEY = "mySecret";
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
            var password = HashPassword(user.Password+SECRET_KEY);

            user.Password = password;

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
            var hashPassword = HashPassword(password+SECRET_KEY);
            return await _repository.Table.SingleOrDefaultAsync(x => x.Email == email && x.Password == hashPassword);
        }

        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
