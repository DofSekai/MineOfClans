using Backend.Common.DAO;

namespace Backend.Database.Interfaces;

public interface ILevelMinesDataAccess 
{
    IAsyncEnumerable<LevelMine> GetAllLevelMines();
    Task<LevelMine?> GetById(int id);
    Task Create(LevelMine levelMine);
}