namespace Backend.Common.DTO;
public class LevelMine 
{
    public int Id { get; set; }
    public int IronRate { get; set; }
    public int DiamondRate { get; set; }
    public int EmeraldRate { get; set; }
    public int IronMaxRate { get; set; }
    public int DiamondMaxRate { get; set; }
    public int EmeraldMaxRate { get; set; }
}

public static class LevelMineDAOtoDTOHelper 
{
    public static DTO.LevelMine ToDto(this DAO.LevelMine originalLevelMine) 
    {
        return new DTO.LevelMine()
        {
            Id = originalLevelMine.Id,
            IronRate = originalLevelMine.IronRate,
            DiamondRate = originalLevelMine.DiamondRate,
            EmeraldRate = originalLevelMine.EmeraldRate,
            IronMaxRate = originalLevelMine.IronMaxRate,
            DiamondMaxRate = originalLevelMine.DiamondMaxRate,
            EmeraldMaxRate = originalLevelMine.EmeraldMaxRate
        };
    }

    public static DAO.LevelMine ToDAO(this DTO.LevelMine originalLevelMine)
    {
        return new DAO.LevelMine(){
            Id = originalLevelMine.Id,
            IronRate = originalLevelMine.IronRate,
            DiamondRate = originalLevelMine.DiamondRate,
            EmeraldRate = originalLevelMine.EmeraldRate,
            IronMaxRate = originalLevelMine.IronMaxRate,
            DiamondMaxRate = originalLevelMine.DiamondMaxRate,
            EmeraldMaxRate = originalLevelMine.EmeraldMaxRate
        };
    }
}
