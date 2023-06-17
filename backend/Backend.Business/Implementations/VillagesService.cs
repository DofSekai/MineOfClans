using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Business.Database.Interfaces;
using Microsoft.Extensions.Logging;
using LevelMine = Backend.Common.DAO.LevelMine;

namespace Backend.Business.Implementations {
    public class VillagesService : IVillagesService {
        private readonly IVillagesDataAccess _villagesDataAccess;
        private readonly ILevelMinesDataAccess _levelMinesDataAccess;
        private readonly IRankupMinesDataAccess _rankupMinesDataAccess;
        private readonly ILogger<VillagesService> _logger;
        
        public VillagesService(IVillagesDataAccess villagesDataAccess, IRankupMinesDataAccess rankupMinesDataAccess, ILevelMinesDataAccess levelMinesDataAccess, ILogger<VillagesService> logger) {
            _villagesDataAccess = villagesDataAccess;
            _rankupMinesDataAccess = rankupMinesDataAccess;
            _levelMinesDataAccess = levelMinesDataAccess;
            _logger = logger;
        }
        
        public async Task<IEnumerable<Village>> GetAllVillages(CancellationToken cancellationToken) {
            try {
                List<Village> villages = new List<Village>();
                await foreach (var user in _villagesDataAccess.GetAllVillages()) {
                    cancellationToken.ThrowIfCancellationRequested();
                    villages.Add(user.ToDto());
                }

                return villages;
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task<Village?> GetById(int id) {
            try {
                var data = await _villagesDataAccess.GetById(id);
                return data?.ToDto();
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task Create(Village village) {
            if (village == null) {
                throw new ArgumentException("Village object is invalid !");
            }

            try {
                await _villagesDataAccess.Create(village.ToDAO());
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task Update(int id) {
            var village = await _villagesDataAccess.GetById(id);
            int LastUpdate = village.LastUpdate;
            int NewLastUpdate = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            int Multiplicator = NewLastUpdate - LastUpdate;
            LevelMine LevelMine = village.LevelMine;
            int IronRate = LevelMine.IronRate;
            int DiamondRate = LevelMine.DiamondRate;
            int EmeraldRate = LevelMine.EmeraldRate;
            int IronMaxRate = LevelMine.IronMaxRate;
            int DiamondMaxRate = LevelMine.DiamondMaxRate;
            int EmeraldMaxRate = LevelMine.EmeraldMaxRate;
            
            // Update Resources
            if (village.Irons + Multiplicator * IronRate < IronMaxRate) { 
                village.Irons += Multiplicator * IronRate;
            }
            else
            {
                village.Irons = IronMaxRate;
            }

            if (village.Diamonds + Multiplicator * DiamondRate < DiamondMaxRate) {
                village.Diamonds += Multiplicator * DiamondRate;
            }
            else
            {
                village.Diamonds = DiamondMaxRate;
            }
            
            if (village.Emeralds + Multiplicator * EmeraldRate < EmeraldMaxRate) {
                village.Emeralds += Multiplicator * EmeraldRate;
            }
            else
            {
                village.Emeralds = EmeraldMaxRate;
            }

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

            village.LastUpdate = NewLastUpdate;

            await _villagesDataAccess.Update(village.Id);
        }
    }
}
