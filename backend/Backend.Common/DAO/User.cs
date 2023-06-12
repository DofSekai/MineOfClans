namespace Backend.Common.DAO {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public DateTime LastUpdate { get; set; } =  DateTime.Now;
    }
}
