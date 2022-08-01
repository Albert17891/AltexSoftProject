namespace Booking.Services.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string Code = "Object Not Found";
        public ObjectNotFoundException(string errorText):base(errorText)
        {

        }
    }
}
