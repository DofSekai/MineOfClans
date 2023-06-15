using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations {
    public class LevelMinesDatabaseAccess : ILevelMinesDataAccess {
        private readonly DatabaseContext _databaseContext;
        public LevelMinesDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        
        public IAsyncEnumerable<LevelMine> GetAllLevelMines() {
            return _databaseContext.levelMines.AsAsyncEnumerable();
        }

        public async Task<LevelMine?> GetById(int id) {
            return await _databaseContext.levelMines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(LevelMine levelmine) {
            _databaseContext.levelMines.Add(levelmine);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
