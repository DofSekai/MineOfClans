using Backend.Common.DAO;

namespace Business.Database.Interfaces {
    
    public interface IVillagesDataAccess {
        IAsyncEnumerable<Village> GetAllVillages();
        Task<Village?> GetById(int id);
        Task Create(Village village);
        Task Update(int id);
        Task UpdateGolem(int id);
        Task UpdateWall(int id);
        Task UpdateTower(int id);
        Task UpdateHdv(int id);
        Task UpdateMine(int id);
    }
}
