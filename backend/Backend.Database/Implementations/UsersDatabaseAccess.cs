using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations {
    public class UsersDatabaseAccess : IUsersDataAccess {
        private readonly DatabaseContext _databaseContext;
        public UsersDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        
        public IAsyncEnumerable<User> GetAllUsers() {
            return _databaseContext.users
                .Include(x => x.Village).ThenInclude(x => x.LevelMine)
                .Include(x => x.Village).ThenInclude(x => x.LevelHdv)
                .AsAsyncEnumerable();
        }

        public async Task<User?> GetById(int id) {
            return await _databaseContext.users
                .Include(x => x.Village).ThenInclude(x => x.LevelMine)
                .Include(x => x.Village).ThenInclude(x => x.LevelHdv)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> SearchByName(string name) {
            return _databaseContext.users
                .Include(x => x.Village).ThenInclude(x => x.LevelMine)
                .Include(x => x.Village).ThenInclude(x => x.LevelHdv)
                .Where(x => x.Name.Contains(name));
        }

        public async Task Create(User user) {
            _databaseContext.users.Add(user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
