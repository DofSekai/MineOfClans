using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations;

public class LevelMinesDatabaseAccess : ILevelMinesDataAccess
{
    private readonly DatabaseContext _databaseContext;
    public LevelMinesDatabaseAccess(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }
        
    public IAsyncEnumerable<LevelMine> GetAllLevelMines()
    {
        return _databaseContext.LevelMines.AsAsyncEnumerable();
    }

    public async Task<LevelMine?> GetById(int id) {
        return await _databaseContext.LevelMines.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(LevelMine levelMine) {
        _databaseContext.LevelMines.Add(levelMine);
        await _databaseContext.SaveChangesAsync();
    }
}
