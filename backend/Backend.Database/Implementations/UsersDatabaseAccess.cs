using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations;

public class UsersDatabaseAccess : IUsersDataAccess 
{
    private readonly DatabaseContext _databaseContext;
    public UsersDatabaseAccess(DatabaseContext databaseContext) 
    {
        _databaseContext = databaseContext;
    }
        
    public IAsyncEnumerable<User> GetAllUsers() 
    {
        return _databaseContext.Users.AsAsyncEnumerable();
    }

    public async Task<User?> GetById(int id) 
    {
        return await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<IEnumerable<User>> SearchByName(string name) 
    {
        return Task.FromResult<IEnumerable<User>>(_databaseContext.Users.Where(x => x.Name.Contains(name)));
    }

    public async Task Create(User user) 
    {
        _databaseContext.Users.Add(user);
        await _databaseContext.SaveChangesAsync();
    }
}
