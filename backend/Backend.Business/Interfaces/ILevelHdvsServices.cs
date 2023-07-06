using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface ILevelHdvsService 
{
    Task<IEnumerable<LevelHdv>> GetAllLevelHdvs(CancellationToken cancellationToken);
    Task<LevelHdv?> GetById(int id);
    Task Create(LevelHdv levelHdv);
}