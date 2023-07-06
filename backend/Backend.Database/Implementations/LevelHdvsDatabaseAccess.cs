using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations;

public class LevelHdvsDatabaseAccess : ILevelHdvsDataAccess {
    private readonly DatabaseContext _databaseContext;
    public LevelHdvsDatabaseAccess(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }
        
    public IAsyncEnumerable<LevelHdv> GetAllLevelHdvs() {
        return _databaseContext.LevelHdvs.AsAsyncEnumerable();
    }

    public async Task<LevelHdv?> GetById(int id) {
        return await _databaseContext.LevelHdvs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(LevelHdv levelHdv) {
        _databaseContext.LevelHdvs.Add(levelHdv);
        await _databaseContext.SaveChangesAsync();
    }
}