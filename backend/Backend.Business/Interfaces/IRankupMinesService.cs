using Backend.Common.DTO;

namespace Backend.Business.Interfaces;

public interface IRankupMinesService
{
    Task<RankupMine?> GetById(int id);
}