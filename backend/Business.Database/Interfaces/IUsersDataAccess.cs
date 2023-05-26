using Backend.Common.DAO;

namespace Business.Database.Interfaces {
    public interface IUsersDataAccess {
        IAsyncEnumerable<User> GetAllUsers();
        Task<User?> GetById(int id);
        Task<IEnumerable<User>> SearchByName(string name);
        Task Create(User user);
    }
}
