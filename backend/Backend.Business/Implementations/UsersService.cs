using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Business.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations {
    public class UsersService : IUsersService {
        private readonly IUsersDataAccess _usersDataAccess;
        private readonly ILogger<UsersService> _logger;
        
        public UsersService(IUsersDataAccess gamesDataAccess, ILogger<UsersService> logger) {
            _usersDataAccess = gamesDataAccess;
            _logger = logger;
        }
        
        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken) {
            try {
                List<User> users = new List<User>();
                await foreach (var user in _usersDataAccess.GetAllUsers()) {
                    cancellationToken.ThrowIfCancellationRequested();
                    users.Add(user.ToDto());
                }

                return users;
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);

                throw;
            }
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Create(User user)
        {
            throw new NotImplementedException();
        }
    }
}
