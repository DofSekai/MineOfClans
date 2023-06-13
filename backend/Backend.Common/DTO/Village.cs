namespace Backend.Common.DTO {
    public class Village {
        public int Id { get; set; }
        public int Irons { get; set; } = 30;
        public int Diamonds { get; set; } = 20;
        public int Emeralds { get; set; } = 10;
        public int WallLevel { get; set; }
        public int GolemLevel { get; set; }
        public int LastUpdate { get; set; } = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }
    
    public static class VillageDAOtoDTOHelper {
        public static DTO.Village ToDto(this DAO.Village originalVillage) {
            return new DTO.Village() {
                Id = originalVillage.Id,
                Irons = originalVillage.Irons,
                Diamonds = originalVillage.Diamonds,
                Emeralds = originalVillage.Emeralds,
                WallLevel = originalVillage.WallLevel,
                GolemLevel = originalVillage.GolemLevel,
                LastUpdate = originalVillage.LastUpdate
            };
        }

        public static DAO.Village ToDAO(this DTO.Village originalVillage) {
            return new DAO.Village() {
                Id = originalVillage.Id,
                Irons = originalVillage.Irons,
                Diamonds = originalVillage.Diamonds,
                Emeralds = originalVillage.Emeralds,
                WallLevel = originalVillage.WallLevel,
                GolemLevel = originalVillage.GolemLevel,
                LastUpdate = originalVillage.LastUpdate
            };
        }
    }
}
