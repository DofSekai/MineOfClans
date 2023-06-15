namespace Backend.Common.DTO {
    public class MaxItems {
        public int Id { get; set; }
        public int MaxGolems { get; set; }
        public int MaxWalls { get; set; }
        public int MaxTowers { get; set; }
    }
    
    public static class MaxItemsDAOtoDTOHelper {
        public static DTO.MaxItems ToDto(this DAO.MaxItems originalMaxItems) {
            return new DTO.MaxItems() {
                Id = originalMaxItems.Id,
                MaxGolems = originalMaxItems.MaxGolems,
                MaxWalls = originalMaxItems.MaxWalls,
                MaxTowers = originalMaxItems.MaxTowers
            };
        }

        public static DAO.MaxItems ToDAO(this DTO.MaxItems originalMaxItems) {
            return new DAO.MaxItems() {
                Id = originalMaxItems.Id,
                MaxGolems = originalMaxItems.MaxGolems,
                MaxWalls = originalMaxItems.MaxWalls,
                MaxTowers = originalMaxItems.MaxTowers
            };
        }
    }
}
