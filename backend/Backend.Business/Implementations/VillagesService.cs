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
                throw new ArgumentException("Game object is invalid !");
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

            if (village.Irons + Multiplicator * 5 < 200) { // en base
                village.Irons += Multiplicator * 5; //en base
            }

            if (village.Diamonds + Multiplicator * 5 < 200) { // en base
                village.Diamonds += Multiplicator * 3; //en base
            }
            
            if (village.Emeralds + Multiplicator * 5 < 200) { // en base
                village.Emeralds += Multiplicator * 1; //en base
            }

            village.LastUpdate = NewLastUpdate;

            await _villagesDataAccess.Update(village.Id);
        }
    }
}
