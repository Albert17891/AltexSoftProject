namespace BookingApi.Models.DTO
{
    public class BookingWithApartmentDTO
    {
        public int CustomerId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int? Status { get; set; }
        public ApartmentForBookingDTO? Apartment { get; set; }
    }
}
