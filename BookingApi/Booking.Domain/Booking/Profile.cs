namespace Booking.Domain.Booking
{
    public class Profile
    {     
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public Apartment? Apartment { get; set; }
        public List<Order>? Order { get; set; }
    }
}
