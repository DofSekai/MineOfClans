using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations;

public class VillagesDatabaseAccess : IVillagesDataAccess 
{
    private readonly DatabaseContext _databaseContext;
    public VillagesDatabaseAccess(DatabaseContext databaseContext) 
    {
        _databaseContext = databaseContext;
    }
        
    public IAsyncEnumerable<Village> GetAllVillages() 
    {
        return _databaseContext.Villages
            .Include(x => x.User)
            .Include(x => x.LevelMine)
            .Include(x => x.LevelHdv)
            .AsAsyncEnumerable();
    }
    
    public IAsyncEnumerable<Village> GetAllVillagesByUserId(int id) 
    {
        return _databaseContext.Villages
            .Include(x => x.User)
            .Include(x => x.LevelMine)
            .Include(x => x.LevelHdv)
            .Where(x=> x.User.Id == id)
            .AsAsyncEnumerable();
    }

    public async Task<Village?> GetById(int id) 
    {
        return await _databaseContext.Villages
            .Include(x => x.User)
            .Include(x => x.LevelMine)
            .Include(x => x.LevelHdv)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<IEnumerable<Village>> SearchByName(string name) 
    {
        return Task.FromResult<IEnumerable<Village>>(_databaseContext.Villages
            .Include(x => x.User)
            .Include(x => x.LevelMine)
            .Include(x => x.LevelHdv)
            .Where(x => x.Name.Contains(name)));
    }

    public async Task Create(Village village) 
    {
        _databaseContext.Villages.Add(village);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task Update(int id) 
    {
        var village = await GetById(id);
        _databaseContext.Villages.Update(village);
        await _databaseContext.SaveChangesAsync();
    }
}
