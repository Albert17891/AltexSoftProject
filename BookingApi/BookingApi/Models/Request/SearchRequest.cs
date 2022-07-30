namespace BookingApi.Models.Request
{
    public class SearchRequest
    {
        public string? City { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }


    }
}
