namespace Backend.Common.DAO {
    public class Village {
        public int Id { get; set; }
        public int Irons { get; set; }
        public int Diamonds { get; set; }
        public int Emeralds { get; set; }
        public int WallLevel { get; set; }
        public int GolemLevel { get; set; }
        public double LastUpdate { get; set; } = ((TimeSpan)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds;
    }
}
