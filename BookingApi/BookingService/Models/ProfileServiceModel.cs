namespace Booking.Services.Models
{
    public class ProfileServiceModel
    {     
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public ApartmentServiceModel? Apartment { get; set; }
        public List<GuestServiceModel>? Guests { get; set; }
        public List<BookingServiceModel>? Bookings { get; set; }
    }
}
