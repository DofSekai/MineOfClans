using Backend.Business.Interfaces;
using Backend.Common.DTO;
using Backend.Database.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Business.Implementations {
    public class RankupMinesService : IRankupMinesService {
        private readonly IRankupMinesDataAccess _rankupMinesDataAccess;
        private readonly ILogger<RankupMinesService> _logger;
        
        public RankupMinesService(IRankupMinesDataAccess rankupMinesDataAccess, ILogger<RankupMinesService> logger) {
            _rankupMinesDataAccess = rankupMinesDataAccess;
            _logger = logger;
        }

        public async Task<RankupMine?> GetById(int id) {
            try {
                var data = await _rankupMinesDataAccess.GetById(id);
                return data?.ToDto();
            } catch (Exception e) {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                throw;
            }
        }
    }
}
