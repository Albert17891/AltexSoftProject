namespace Booking.Services.Models
{
    public class JWTConfiguration
    {
        public string? Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
