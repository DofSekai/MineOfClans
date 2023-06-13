using Backend.Common.DAO;

namespace Business.Database.Interfaces {
    
    public interface IVillagesDataAccess {
        IAsyncEnumerable<Village> GetAllVillages();
        Task<Village?> GetById(int id);
        Task Create(Village village);
        Task Update(int id);
    }
}
