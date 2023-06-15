namespace Backend.Common.DAO {
    public class Village {
        public int Id { get; set; }
        public int Irons { get; set; } = 30;
        public int Diamonds { get; set; } = 20;
        public int Emeralds { get; set; } = 10;
        public int WallLevel { get; set; }
        public int GolemLevel { get; set; }
        public LevelMine LevelMine { get; set; } 
        public int LevelMineId { get; set; }
        public int LevelHDV { get; set; } = 1;
        public int LastUpdate { get; set; } = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }
}
