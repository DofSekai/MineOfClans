using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations {
    public class RankupHdvsDatabaseAccess : IRankupHdvsDataAccess {
        private readonly DatabaseContext _databaseContext;
        public RankupHdvsDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<RankupHdv?> GetById(int id) {
            return await _databaseContext.rankupHdvs.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
