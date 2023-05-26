namespace Backend.Common.DTO {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
    
    public static class GameDAOtoDTOHelper {
        public static DTO.User ToDto(this DAO.User originalUser) {
            return new DTO.User() {
                Id = originalUser.Id,
                Name = originalUser.Name,
                Level = originalUser.Level
            };
        }

        public static DAO.User ToDAO(this DTO.User originalUser) {
            return new DAO.User() {
                Id = originalUser.Id,
                Name = originalUser.Name,
                Level = originalUser.Level
            };
        }
    }
}
