using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;
using LevelMine = Backend.Common.DAO.LevelMine;
using LevelHdv = Backend.Common.DAO.LevelHdv;

namespace Backend.Business.Implementations;

public class VillagesService : IVillagesService
{
    private readonly IVillagesDataAccess _villagesDataAccess;
    private readonly ILevelMinesDataAccess _levelMinesDataAccess;
    private readonly ILevelHdvsDataAccess _levelHdvsDataAccess;
    private readonly IRankupMinesDataAccess _rankupMinesDataAccess;
    private readonly IRankupHdvsDataAccess _rankupHdvsDataAccess;
    private readonly ILogger<VillagesService> _logger;

    public VillagesService(IVillagesDataAccess villagesDataAccess, ILevelMinesDataAccess levelMinesDataAccess,
        ILevelHdvsDataAccess levelHdvsDataAccess, IRankupMinesDataAccess rankupMinesDataAccess,
        IRankupHdvsDataAccess rankupHdvsDataAccess, ILogger<VillagesService> logger)
    {
        _villagesDataAccess = villagesDataAccess;
        _levelMinesDataAccess = levelMinesDataAccess;
        _levelHdvsDataAccess = levelHdvsDataAccess;
        _rankupMinesDataAccess = rankupMinesDataAccess;
        _rankupHdvsDataAccess = rankupHdvsDataAccess;
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

    public async Task UpdateMine(int id)
    {
        var village = await _villagesDataAccess.GetById(id);
        LevelMine LevelMine = village.LevelMine;
        var RankupMine = await _rankupMinesDataAccess.GetById(LevelMine.Id);
        if (RankupMine != null)
        {
            if (village.Irons >= RankupMine.Irons && village.Diamonds >= RankupMine.Diamonds &&
                village.Emeralds >= RankupMine.Emeralds)
            {
                LevelMine NextLevelMine = await _levelMinesDataAccess.GetById(village.LevelMineId + 1);
                if (NextLevelMine != null)
                {
                    village.Irons -= RankupMine.Irons;
                    village.Diamonds -= RankupMine.Diamonds;
                    village.Emeralds -= RankupMine.Emeralds;
                    village.LevelMine = NextLevelMine;
                }
            }
        }

        await _villagesDataAccess.Update(village.Id);
    }

    public async Task UpdateHdv(int id)
    {
        var village = await _villagesDataAccess.GetById(id);
        LevelHdv LevelHdv = village.LevelHdv;
        var RankupHdv = await _rankupHdvsDataAccess.GetById(LevelHdv.Id);

        if (RankupHdv != null)
        {

            if (village.Irons >= RankupHdv.Irons && village.Diamonds >= RankupHdv.Diamonds &&
                village.Emeralds >= RankupHdv.Emeralds)
            {
                LevelHdv NextLevelHdv = await _levelHdvsDataAccess.GetById(village.LevelHdvId + 1);

                if (NextLevelHdv != null)
                {
                    village.Irons -= RankupHdv.Irons;
                    village.Diamonds -= RankupHdv.Diamonds;
                    village.Emeralds -= RankupHdv.Emeralds;
                    village.LevelHdv = NextLevelHdv;
                }
            }
        }

        await _villagesDataAccess.Update(village.Id);
    }

    public async Task UpdateGolem(int id)
    {
        var village = await _villagesDataAccess.GetById(id);

        if (village.Irons >= 600 && village.Golems < village.LevelHdv.MaxGolems)
        {
            village.Golems += 1;
            village.Irons -= 600;
        }

        await _villagesDataAccess.Update(village.Id);
    }

    public async Task UpdateWall(int id)
    {
        var village = await _villagesDataAccess.GetById(id);

        if (village.Diamonds >= 50 && village.Walls < village.LevelHdv.MaxWalls)
        {
            village.Walls += 1;
            village.Diamonds -= 50;
        }

        await _villagesDataAccess.Update(village.Id);
    }

    public async Task UpdateTower(int id)
    {
        var village = await _villagesDataAccess.GetById(id);

        if (village.Emeralds >= 100 && village.Towers < village.LevelHdv.MaxTowers)
        {
            village.Towers += 1;
            village.Emeralds -= 100;
        }

        await _villagesDataAccess.Update(village.Id);
    }
}
