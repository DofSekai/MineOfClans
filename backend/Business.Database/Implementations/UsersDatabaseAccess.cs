using Backend.Common.DAO;
using Business.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Database.Implementations {
    public class UsersDatabaseAccess : IUsersDataAccess {
        private readonly DatabaseContext _databaseContext;
        public UsersDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        
        public IAsyncEnumerable<User> GetAllUsers() {
            return _databaseContext.users.AsAsyncEnumerable();
        }

        public async Task<User?> GetById(int id) {
            return await _databaseContext.users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> SearchByName(string name) {
            return _databaseContext.users.Where(x => x.Name.Contains(name));
        }

        public async Task Create(User user) {
            _databaseContext.users.Add(user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
