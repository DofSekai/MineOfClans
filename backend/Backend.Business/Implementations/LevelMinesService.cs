using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations {
    public class LevelMinesService : ILevelMinesService {
        private readonly ILevelMinesDataAccess _levelMinesDataAccess;
        private readonly ILogger<LevelMinesService> _logger;
        
        public LevelMinesService(ILevelMinesDataAccess levelMinesDataAccess, ILogger<LevelMinesService> logger) {
            _levelMinesDataAccess = levelMinesDataAccess;
            _logger = logger;
        }
        
        public async Task<IEnumerable<LevelMine>> GetAllLevelMines(CancellationToken cancellationToken) {
            try {
                List<LevelMine> levelMines = new List<LevelMine>();
                await foreach (var levelMine in _levelMinesDataAccess.GetAllLevelMines()) {
                    cancellationToken.ThrowIfCancellationRequested();
                    levelMines.Add(levelMine.ToDto());
                }

                return levelMines;
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task<LevelMine?> GetById(int id) {
            try {
                var data = await _levelMinesDataAccess.GetById(id);
                return data?.ToDto();
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }

        public async Task Create(LevelMine levelMine) {
            if (levelMine == null) {
                throw new ArgumentException("LevelMine object is invalid !");
            }

            try {
                await _levelMinesDataAccess.Create(levelMine.ToDAO());
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}
