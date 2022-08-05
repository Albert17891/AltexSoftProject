namespace Booking.Services.Models
{
    public class GuestServiceModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string? Photo { get; set; }
        public int? Status { get; set; }
    }
}
