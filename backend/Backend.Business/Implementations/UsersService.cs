using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations {
    public class UsersService : IUsersService {
        private readonly IUsersDataAccess _usersDataAccess;
        private readonly ILogger<UsersService> _logger;
        
        public UsersService(IUsersDataAccess usersDataAccess, ILogger<UsersService> logger) {
            _usersDataAccess = usersDataAccess;
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

        public async Task<User?> GetById(int id) {
            try {
                var data = await _usersDataAccess.GetById(id);
                return data?.ToDto();
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task<IEnumerable<User>> SearchByName(string name) {
            try {
                return (await _usersDataAccess.SearchByName(name)).Select(x => x.ToDto());
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);

                throw;
            }
        }

        public async Task<User> Create(UserCreationRequest request) {
            if (request == null) {
                throw new ArgumentException("User object is invalid !");
            }

            if (string.IsNullOrWhiteSpace(request.Name)) {
                throw new ArgumentException("Name is empty !");
            }

            var user = new User()
            {
                Name = request.Name,
                Village = new Village()
            };

            try {
                await _usersDataAccess.Create(user.ToDAO());

                return (await _usersDataAccess.SearchByName(request.Name)).FirstOrDefault()?.ToDto();
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}
