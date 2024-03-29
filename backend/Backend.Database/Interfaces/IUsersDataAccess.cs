using Backend.Common.DAO;

namespace Backend.Database.Interfaces;

public interface IUsersDataAccess 
{
    IAsyncEnumerable<User> GetAllUsers();
    Task<User?> GetById(int id);
    Task<IEnumerable<User>> SearchByName(string name);
    Task Create(User user);
    Task Update(int id);
    IAsyncEnumerable<User> GetRanking();
}
