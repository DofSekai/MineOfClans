using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations;

public class RankupHdvsService : IRankupHdvsService
{
    private readonly IRankupHdvsDataAccess _rankupHdvsDataAccess;
    private readonly ILogger<RankupHdvsService> _logger;
        
    public RankupHdvsService(IRankupHdvsDataAccess rankupHdvsDataAccess, ILogger<RankupHdvsService> logger)
    {
        _rankupHdvsDataAccess = rankupHdvsDataAccess;
        _logger = logger;
    }

    public async Task<RankupHdv?> GetById(int id)
    {
        try 
        {
            var data = await _rankupHdvsDataAccess.GetById(id);
            return data?.ToDto();
        } 
        catch (Exception e) {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }
}
