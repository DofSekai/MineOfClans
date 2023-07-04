namespace Backend.Common.DAO 
{
    public class Village 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Irons { get; set; }
        public int Diamonds { get; set; }
        public int Emeralds { get; set; }
        public int Golems { get; set; }
        public int Walls { get; set; }
        public int Towers { get; set; }
        public int LastUpdate { get; set; } = (int) (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }
}
