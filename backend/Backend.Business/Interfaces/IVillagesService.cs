using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface IVillagesService {
    Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken);
    Task<Village?> GetById(int id);
    Task<IEnumerable<Village>> SearchByName(string name);
    Task<Village> Create(VillageCreationRequest village);
}
