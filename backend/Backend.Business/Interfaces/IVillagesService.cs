using Backend.Common.DTO;

namespace Backend.Business.Interfaces
{
    public interface IVillagesService {
        Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken);
        Task<Village?> GetById(int id);
        Task Create(Village village);
        Task Update(int id);
    }
}
