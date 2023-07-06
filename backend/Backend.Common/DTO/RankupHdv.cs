namespace Backend.Common.DTO;

public class RankupHdv
{
    public int Id { get; set; }
    public int Irons { get; set; }
    public int Diamonds { get; set; }
    public int Emeralds { get; set; }
}

public static class RankupHdvDAOtoDTOHelper
{
    public static DTO.RankupHdv ToDto(this DAO.RankupHdv originalRankupHdv)
    {
        return new DTO.RankupHdv()
        {
            Id = originalRankupHdv.Id,
            Irons = originalRankupHdv.Irons,
            Diamonds = originalRankupHdv.Diamonds,
            Emeralds = originalRankupHdv.Emeralds
        };
    }

    public static DAO.RankupHdv ToDAO(this DTO.RankupHdv originalRankupHdv)
    {
        return new DAO.RankupHdv()
        {
            Id = originalRankupHdv.Id,
            Irons = originalRankupHdv.Irons,
            Diamonds = originalRankupHdv.Diamonds,
            Emeralds = originalRankupHdv.Emeralds
        };
    }
}
