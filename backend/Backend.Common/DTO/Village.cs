using System.Text.Json.Serialization;

namespace Backend.Common.DTO;

public class Village 
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }
    public User User { get; set; }
}
    
public static class VillageDAOtoDTOHelper 
{
    public static DTO.Village ToDto(this DAO.Village originalVillage) 
    {
        return new DTO.Village() {
            Id = originalVillage.Id,
            Name = originalVillage.Name,
            UserId = originalVillage.UserId,
            User = originalVillage.User.ToDto()
        };
    }

    public static DAO.Village ToDAO(this DTO.Village originalVillage) 
    {
        return new DAO.Village() {
            Id = originalVillage.Id,
            Name = originalVillage.Name,
            UserId = originalVillage.UserId
        };
    }
}
