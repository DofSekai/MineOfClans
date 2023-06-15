namespace Backend.Common.DTO {
    public class RankupMine {
        public int Id { get; set; }
        public int Irons { get; set; }
        public int Diamonds { get; set; }
        public int Emeralds { get; set; }
    }
    
    public static class RankupMineMineDAOtoDTOHelper {
        public static DTO.RankupMine ToDto(this DAO.RankupMine originalRankupMine)
        {
            return new DTO.RankupMine()
            {
                Id = originalRankupMine.Id,
                Irons = originalRankupMine.Irons,
                Diamonds = originalRankupMine.Diamonds,
                Emeralds = originalRankupMine.Emeralds
            };
        }

        public static DAO.RankupMine ToDAO(this DTO.RankupMine originalRankupMine) {
            return new DAO.RankupMine() {
                Id = originalRankupMine.Id,
                Irons = originalRankupMine.Irons,
                Diamonds = originalRankupMine.Diamonds,
                Emeralds = originalRankupMine.Emeralds
            };
        }
    }
}
