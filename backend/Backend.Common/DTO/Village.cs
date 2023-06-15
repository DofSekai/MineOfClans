namespace Backend.Common.DTO {
    public class Village {
        public int Id { get; set; }
        public int Irons { get; set; } = 30;
        public int Diamonds { get; set; } = 20;
        public int Emeralds { get; set; } = 10;
        public int Walls { get; set; }
        public int Golems { get; set; }
        public int Towers { get; set; }
        public LevelMine LevelMine { get; set; }
        public int LevelMineId { get; set; } = 1;
        public MaxItems LevelHDV { get; set; }
        public int LevelHDVId { get; set; } = 1;
        public int LastUpdate { get; set; } = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }
    
    public static class VillageDAOtoDTOHelper {
        public static DTO.Village ToDto(this DAO.Village originalVillage) {
            return new DTO.Village() {
                Id = originalVillage.Id,
                Irons = originalVillage.Irons,
                Diamonds = originalVillage.Diamonds,
                Emeralds = originalVillage.Emeralds,
                Walls = originalVillage.Walls,
                Golems = originalVillage.Golems,
                Towers = originalVillage.Towers,
                LevelMine = originalVillage.LevelMine.ToDto(),
                LevelMineId = originalVillage.LevelMineId,
                LevelHDV = originalVillage.LevelHDV.ToDto(),
                LevelHDVId = originalVillage.LevelHDVId,
                LastUpdate = originalVillage.LastUpdate
            };
        }

        public static DAO.Village ToDAO(this DTO.Village originalVillage) {
            return new DAO.Village() {
                Id = originalVillage.Id,
                Irons = originalVillage.Irons,
                Diamonds = originalVillage.Diamonds,
                Emeralds = originalVillage.Emeralds,
                Walls = originalVillage.Walls,
                Golems = originalVillage.Golems,
                Towers = originalVillage.Towers,
                LevelMineId = originalVillage.LevelMineId,
                LevelHDVId = originalVillage.LevelHDVId,
                LastUpdate = originalVillage.LastUpdate
            };
        }
    }
}
