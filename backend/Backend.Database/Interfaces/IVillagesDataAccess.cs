using Backend.Common.DAO;

namespace Backend.Database.Interfaces;

public interface IVillagesDataAccess 
{
    IAsyncEnumerable<Village> GetAllVillages();
    IAsyncEnumerable<Village> GetAllVillagesByUserId(int id);
    Task<Village?> GetById(int id);
    Task<IEnumerable<Village>> SearchByName(string name);
    Task Create(Village village);
    Task Update(int id);
    Task UpdateMine(int id);
    Task UpdateHdv(int id);
    Task UpdateGolem(int id);
    Task UpdateWall(int id);
    Task UpdateTower(int id);
}
