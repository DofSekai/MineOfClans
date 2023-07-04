using Backend.Common.DAO;

namespace Backend.Database.Interfaces;

public interface IVillagesDataAccess 
{
    IAsyncEnumerable<Village> GetAllVillages();
    Task<Village?> GetById(int id);
    Task<IEnumerable<Village>> SearchByName(string name);
    Task Create(Village village);
}
