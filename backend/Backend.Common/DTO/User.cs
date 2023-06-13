namespace Backend.Common.DTO {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public Village Village { get; set; }
    }
    
    public static class UserDAOtoDTOHelper {
        public static DTO.User ToDto(this DAO.User originalUser) {
            return new DTO.User() {
                Id = originalUser.Id,
                Name = originalUser.Name,
                Village = originalUser.Village.ToDto()
            };
        }

        public static DAO.User ToDAO(this DTO.User originalUser) {
            return new DAO.User() {
                Id = originalUser.Id,
                Name = originalUser.Name,
                Village = originalUser.Village.ToDAO()
            };
        }
    }
}
