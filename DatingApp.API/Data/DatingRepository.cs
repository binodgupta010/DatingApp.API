using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _conext;

        public DatingRepository(DataContext conext)
        {
            _conext = conext;

        }
        public void Add<T>(T entity) where T : class
        {
            _conext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _conext.Remove(entity);;
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
             var photo = await _conext.Photos.Where(p => p.UserId == userId)
                        .FirstOrDefaultAsync(p => p.IsMain);

            return photo;
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await _conext.Photos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUser(int userId)
        {
           var user = await _conext.Users.Include(p => p.Photos).FirstOrDefaultAsync(id => id.Id ==userId);
           return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _conext.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SavaAll()
        {
           return await _conext.SaveChangesAsync() > 0;
        }
    }
}