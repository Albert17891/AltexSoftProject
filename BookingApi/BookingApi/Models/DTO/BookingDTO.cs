namespace BookingApi.Models.DTO
{
    public class BookingDTO
    {
        public string? City { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? Status { get; set; }
    }
}
