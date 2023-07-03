using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface IUsersService {
    Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
    Task<User?> GetById(int id);
    Task<IEnumerable<User>> SearchByName(string name);
    Task<User> Create(UserCreationRequest user);
}
