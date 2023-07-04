using System.Text.Json.Serialization;

namespace Backend.Common.DTO;

public class Village 
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }
    public User User { get; set; }
    public int Irons { get; set; }
    public int Diamonds { get; set; }
    public int Emeralds { get; set; }
    public int Golems { get; set; }
    public int Walls { get; set; }
    public int Towers { get; set; }
    [JsonIgnore] public int LevelMineId { get; set; } = 1;
    public LevelMine LevelMine { get; set; }
    public int LastUpdate { get; set; } = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
}
    
public static class VillageDAOtoDTOHelper 
{
    public static DTO.Village ToDto(this DAO.Village originalVillage) 
    {
        return new DTO.Village() {
            Id = originalVillage.Id,
            Name = originalVillage.Name,
            UserId = originalVillage.UserId,
            User = originalVillage.User.ToDto(),
            Irons = originalVillage.Irons,
            Diamonds = originalVillage.Diamonds,
            Emeralds = originalVillage.Emeralds,
            Golems = originalVillage.Golems,
            Walls = originalVillage.Walls,
            Towers = originalVillage.Towers,
            LevelMineId = originalVillage.LevelMineId,
            LevelMine = originalVillage.LevelMine.ToDto(),
            LastUpdate = originalVillage.LastUpdate
        };
    }

    public static DAO.Village ToDAO(this DTO.Village originalVillage) 
    {
        return new DAO.Village() {
            Id = originalVillage.Id,
            Name = originalVillage.Name,
            UserId = originalVillage.UserId,
            Irons = originalVillage.Irons,
            Diamonds = originalVillage.Diamonds,
            Emeralds = originalVillage.Emeralds,
            Golems = originalVillage.Golems,
            Walls = originalVillage.Walls,
            Towers = originalVillage.Towers,
            LevelMineId = originalVillage.LevelMineId,
            LastUpdate = originalVillage.LastUpdate
        };
    }
}
