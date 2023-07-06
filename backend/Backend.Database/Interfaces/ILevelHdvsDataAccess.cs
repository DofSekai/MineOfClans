using Backend.Common.DAO;

namespace Backend.Database.Interfaces;

public interface ILevelHdvsDataAccess
{
    IAsyncEnumerable<LevelHdv> GetAllLevelHdvs();
    Task<LevelHdv?> GetById(int id);
    Task Create(LevelHdv levelHdv);
}