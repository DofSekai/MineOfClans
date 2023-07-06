using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface ILevelMinesService
{
    Task<IEnumerable<LevelMine>> GetAllLevelMines(CancellationToken cancellationToken);
    Task<LevelMine?> GetById(int id);
    Task Create(LevelMine levelMine);
}