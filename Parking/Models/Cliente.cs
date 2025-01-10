namespace Parking.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string identification { get; set; }
        public required  string name { get; set; }
        public required string phone { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
    }
}
