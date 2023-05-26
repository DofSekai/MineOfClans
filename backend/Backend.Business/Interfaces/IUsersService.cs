using Backend.Common.DTO;

namespace Backend.Business.Interfaces
{
    public interface IUsersService {
        Task<IEnumerable<User>> GetAllGames(CancellationToken cancellationToken);
        Task<User?> GetById(int id);
        Task<IEnumerable<User>> SearchByName(string name);
        Task Create(User user);
    }
}
