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
    
    public async Task Update(int id)
    {
        var village = await _villagesDataAccess.GetById(id);
        int NewLastUpdate = (int)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        int Multiplicator = NewLastUpdate - village.LastUpdate;
        
        LevelMine LevelMine = village.LevelMine;
        int IronRate = LevelMine.IronRate;
        int DiamondRate = LevelMine.DiamondRate;
        int EmeraldRate = LevelMine.EmeraldRate;
        int IronMaxRate = LevelMine.IronMaxRate;
        int DiamondMaxRate = LevelMine.DiamondMaxRate;
        int EmeraldMaxRate = LevelMine.EmeraldMaxRate;

        if (village.Irons + Multiplicator * IronRate < IronMaxRate)
        {
            village.Irons += Multiplicator * IronRate;
        }
        else
        {
            village.Irons = IronMaxRate;
        }

        if (village.Diamonds + Multiplicator * DiamondRate < DiamondMaxRate)
        {
            village.Diamonds += Multiplicator * DiamondRate;
        }
        else
        {
            village.Diamonds = DiamondMaxRate;
        }

        if (village.Emeralds + Multiplicator * EmeraldRate < EmeraldMaxRate)
        {
            village.Emeralds += Multiplicator * EmeraldRate;
        }
        else
        {
            village.Emeralds = EmeraldMaxRate;
        }

        village.LastUpdate = NewLastUpdate;

        await _villagesDataAccess.Update(village.Id);
    }
}
