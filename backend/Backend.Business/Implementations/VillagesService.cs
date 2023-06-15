using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Business.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations {
    public class VillagesService : IVillagesService {
        private readonly IVillagesDataAccess _villagesDataAccess;
        private readonly ILogger<VillagesService> _logger;
        
        public VillagesService(IVillagesDataAccess villagesDataAccess, ILogger<VillagesService> logger) {
            _villagesDataAccess = villagesDataAccess;
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

        public async Task UpdateResource(int id) {
            var village = await _villagesDataAccess.GetById(id);
            int LastUpdate = village.LastUpdate;
            int NewLastUpdate = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            int Multiplicator = NewLastUpdate - LastUpdate;
            int IronRate = village.LevelMine.IronRate;
            int DiamondRate = village.LevelMine.DiamondRate;
            int EmeraldRate = village.LevelMine.EmeraldRate;
            int IronMaxRate = village.LevelMine.IronMaxRate;
            int DiamondMaxRate = village.LevelMine.DiamondMaxRate;
            int EmeraldMaxRate = village.LevelMine.EmeraldMaxRate;
            
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

            village.LastUpdate = NewLastUpdate;

            await _villagesDataAccess.Update(village.Id);
        }
    }
}
