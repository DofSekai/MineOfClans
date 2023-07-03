using Backend.Common.DAO;

namespace Backend.Database.Interfaces {
    public interface IRankupHdvsDataAccess {
        Task<RankupHdv?> GetById(int id);
    }
}
