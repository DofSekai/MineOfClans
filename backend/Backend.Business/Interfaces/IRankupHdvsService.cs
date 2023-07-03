using Backend.Common.DTO;

namespace Backend.Business.Interfaces
{
    public interface IRankupHdvsService {
        Task<RankupHdv?> GetById(int id);
    }
}
