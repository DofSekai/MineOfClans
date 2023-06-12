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
            return _databaseContext.villages.AsAsyncEnumerable();
        }

        public async Task<Village?> GetById(int id) {
            return await _databaseContext.villages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Village village) {
            _databaseContext.villages.Add(village);
            await _databaseContext.SaveChangesAsync();
        }
    }
}