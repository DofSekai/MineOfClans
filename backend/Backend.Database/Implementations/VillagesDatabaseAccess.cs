using Backend.Common.DAO;
using Backend.Database;
using Business.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Database.Implementations {
    public class VillagesDatabaseAccess : IVillagesDataAccess {
        private readonly DatabaseContext _databaseContext;
        
        public VillagesDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        
        public IAsyncEnumerable<Village> GetAllVillages() {
            return _databaseContext.villages
                .Include(x => x.LevelMine)
                .Include(x => x.LevelHdv)
                .AsAsyncEnumerable();
        }

        public async Task<Village?> GetById(int id) {
            return await _databaseContext.villages
                .Include(x => x.LevelMine)
                .Include(x => x.LevelHdv)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Village village) {
            _databaseContext.villages.Add(village);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task Update(int id) {
            var village = await GetById(id);
            _databaseContext.villages.Update(village);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
