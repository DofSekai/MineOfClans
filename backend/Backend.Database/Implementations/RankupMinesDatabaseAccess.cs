using Backend.Common.DAO;
using Backend.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Implementations {
    public class RankupMinesDatabaseAccess : IRankupMinesDataAccess {
        private readonly DatabaseContext _databaseContext;
        public RankupMinesDatabaseAccess(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<RankupMine?> GetById(int id) {
            return await _databaseContext.rankupMines.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
