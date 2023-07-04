using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;
using LevelMine = Backend.Common.DAO.LevelMine;

namespace Backend.Business.Implementations;

public class VillagesService : IVillagesService
{
    private readonly IVillagesDataAccess _villagesDataAccess;
    private readonly ILogger<VillagesService> _logger;
        
    public VillagesService(IVillagesDataAccess villagesDataAccess, ILogger<VillagesService> logger)
    {
        _villagesDataAccess = villagesDataAccess;
        _logger = logger;
    }
    
    public async Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken)
    {
        try 
        {
            List<Village> villages = new List<Village>();
            await foreach (var village in _villagesDataAccess.GetAllVillages()) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                villages.Add(village.ToDto());
            }

            return villages;
        } 
        catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }

    public async Task<IEnumerable<Village>> GetAllVillagesByUserId(int id)
    {
        try 
        {
            List<Village> villages = new List<Village>();
            await foreach (var village in _villagesDataAccess.GetAllVillagesByUserId(id)) 
            {
                villages.Add(village.ToDto());
            }

            return villages;
        } 
        catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }

    public async Task<Village?> GetById(int id) 
    {
        try 
        {
            var data = await _villagesDataAccess.GetById(id);
            return data?.ToDto();
        } 
        catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }

    public async Task<IEnumerable<Village>> SearchByName(string name) 
    {
        try 
        {
            return (await _villagesDataAccess.SearchByName(name)).Select(x => x.ToDto());
        } 
        catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);

            throw;
        }
    }

    public async Task<Village> Create(VillageCreationRequest request) 
    {
        if (request == null) 
        {
            throw new ArgumentException("Village object is invalid !");
        }

        if (string.IsNullOrWhiteSpace(request.Name)) 
        {
            throw new ArgumentException("Name is empty !");
        }

        var village = new Village()
        {
            Name = request.Name,
            UserId = request.UserId
        };

        try 
        {
            await _villagesDataAccess.Create(village.ToDAO());
            
            var searchedVillage = (await _villagesDataAccess.SearchByName(request.Name)).FirstOrDefault();

            return searchedVillage?.ToDto()!;
        } 
        catch (Exception e) 
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            throw;
        }
    }
}
