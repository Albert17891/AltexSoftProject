using BookingApi.Models.Request;
using FluentValidation;

namespace BookingApi.Infastructure.Validators
{
    public class OrderValidator:AbstractValidator<OrderRequest>
    {
        public OrderValidator()
        {
            RuleFor(x => x.HostId)
                .NotEmpty()
                .WithMessage("HostID is required");
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerID is required");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required");
            RuleFor(x => x.From)
                .NotEmpty()
                .WithMessage("From is required");
            RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage("To is required");
        }
    }
}
