namespace SupermarketWEB.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Phone_number { get; set; }
        public string? Email { get; set; }
    }
}