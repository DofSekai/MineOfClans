using Backend.Common.DAO;

namespace Backend.Database.Interfaces {
    public interface IRankupMinesDataAccess {
        Task<RankupMine?> GetById(int id);
    }
}
