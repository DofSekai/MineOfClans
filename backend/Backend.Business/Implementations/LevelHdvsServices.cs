using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations;

public class LevelHdvsService : ILevelHdvsService 
{
    private readonly ILevelHdvsDataAccess _levelHdvsDataAccess;
    private readonly ILogger<LevelHdvsService> _logger;
        
    public LevelHdvsService(ILevelHdvsDataAccess levelHdvsDataAccess, ILogger<LevelHdvsService> logger) 
    {
        _levelHdvsDataAccess = levelHdvsDataAccess;
        _logger = logger;
    }
        
    public async Task<IEnumerable<LevelHdv>> GetAllLevelHdvs(CancellationToken cancellationToken)
    {
        try 
        {
            List<LevelHdv> levelHdvs = new List<LevelHdv>();
            await foreach (var levelHdv in _levelHdvsDataAccess.GetAllLevelHdvs())
            {
                cancellationToken.ThrowIfCancellationRequested();
                levelHdvs.Add(levelHdv.ToDto());
            }

            return levelHdvs;
        } 
        catch (Exception e) {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }

    public async Task<LevelHdv?> GetById(int id) 
    {
        try
        {
            var data = await _levelHdvsDataAccess.GetById(id);
            return data?.ToDto();
        } catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }

    public async Task Create(LevelHdv levelHdv)
    {
        if (levelHdv == null)
        {
            throw new ArgumentException("LevelHdv object is invalid !");
        }

        try
        {
            await _levelHdvsDataAccess.Create(levelHdv.ToDAO());
        } 
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }
}