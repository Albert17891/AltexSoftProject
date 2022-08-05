namespace BookingApi.Models.DTO
{
    public class ApartmentForBookingDTO
    {
        public int HostId { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int NumbOfBeds { get; set; }
        public string? Photo { get; set; }
        public int DistanceToCenter { get; set; }
        public string? Description { get; set; }
    }
}
