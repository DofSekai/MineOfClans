using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface IVillagesService {
    Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken);
    Task<IEnumerable<Village>> GetAllVillagesByUserId(int id);
    Task<Village?> GetById(int id);
    Task<IEnumerable<Village>> SearchByName(string name);
    Task<Village> Create(VillageCreationRequest village);
    Task Update(int id);
    Task UpdateMine(int id);
    Task UpdateHdv(int id);
    Task UpdateGolem(int id);
    Task UpdateWall(int id);
    Task UpdateTower(int id);
}
