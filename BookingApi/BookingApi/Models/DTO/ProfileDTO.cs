namespace BookingApi.Models.DTO
{
    public class ProfileDTO
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }       
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public ApartmentDTO? Apartment { get; set; }
        public List<GuestDTO>? Guests { get; set; }
        public List<BookingDTO>? Bookings { get; set; }
    }
}
