namespace Backend.Common.DTO;

public class User 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public List<Village> Villages { get; set; }
    
    public User()
    {
        Villages = new List<Village>();
    }
}
    
public static class UserDAOtoDTOHelper 
{
    public static DTO.User ToDto(this DAO.User originalUser) 
    {
        return new DTO.User() {
            Id = originalUser.Id,
            Name = originalUser.Name,
            Score = originalUser.Score,
            Villages = originalUser.Villages.Select(x => x.ToDto()).ToList()
        };
    }

    public static DAO.User ToDAO(this DTO.User originalUser) 
    {
        return new DAO.User() {
            Id = originalUser.Id,
            Name = originalUser.Name,
            Score = originalUser.Score,
            Villages = originalUser.Villages.Select(x => x.ToDAO()).ToList()
        };
    }
}
