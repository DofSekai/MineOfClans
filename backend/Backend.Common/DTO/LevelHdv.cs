namespace Backend.Common.DTO;

public class LevelHdv
{
    public int Id { get; set; }
    public int MaxGolems { get; set; }
    public int MaxWalls { get; set; }
    public int MaxTowers { get; set; }
}

public static class LevelHdvDAOtoDTOHelper
{
    public static DTO.LevelHdv ToDto(this DAO.LevelHdv originalLevelHdv)
    {
        return new DTO.LevelHdv()
        {
            Id = originalLevelHdv.Id,
            MaxGolems = originalLevelHdv.MaxGolems,
            MaxWalls = originalLevelHdv.MaxWalls,
            MaxTowers = originalLevelHdv.MaxTowers
        };
    }

    public static DAO.LevelHdv ToDAO(this DTO.LevelHdv originalLevelHdv)
    {
        return new DAO.LevelHdv()
        {
            Id = originalLevelHdv.Id,
            MaxGolems = originalLevelHdv.MaxGolems,
            MaxWalls = originalLevelHdv.MaxWalls,
            MaxTowers = originalLevelHdv.MaxTowers
        };
    }
}
