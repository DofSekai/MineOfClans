namespace Backend.Common.DAO {
    public class Village {
        public int Id { get; set; }
        public int Irons { get; set; }
        public int Diamonds { get; set; }
        public int Emeralds { get; set; }
        public int WallLevel { get; set; }
        public int GolemLevel { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
