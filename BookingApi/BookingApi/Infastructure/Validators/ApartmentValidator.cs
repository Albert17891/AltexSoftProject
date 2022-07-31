using BookingApi.Models.Request;
using FluentValidation;

namespace BookingApi.Infastructure.Validators
{
    public class ApartmentValidator:AbstractValidator<ApartmentRequest>
    {
        public ApartmentValidator()
        {
            RuleFor(x => x.HostId)
                .NotEmpty()
                .WithMessage("HostID is Required");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is Required");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is Required");
            RuleFor(x => x.NumbOfBeds)
                .NotEmpty()
                .WithMessage("Number of Beds is Required");
        }
    }
}
