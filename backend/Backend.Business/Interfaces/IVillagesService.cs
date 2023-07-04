using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface IVillagesService {
    Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken);
    Task<IEnumerable<Village>> GetAllVillagesByUserId(int id);
    Task<Village?> GetById(int id);
    Task<IEnumerable<Village>> SearchByName(string name);
    Task<Village> Create(VillageCreationRequest village);
    Task Update(int id);
}
