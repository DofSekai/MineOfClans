namespace Backend.Common.DAO 
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Village> Villages { get; set; }

        public User()
        {
            Villages = new List<Village>();
        }
    }
}
