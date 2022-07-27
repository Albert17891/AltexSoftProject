namespace Booking.Domain.Booking
{
    public class Order
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? Status { get; set; }       
        public Profile? Profile { get; set; }
    }
}
