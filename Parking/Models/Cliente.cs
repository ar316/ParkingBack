namespace Parking.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string identification { get; set; }
        public   string name { get; set; }
        public  string phone { get; set; }
        public  string email { get; set; }
        public  string password { get; set; }
    }
}
