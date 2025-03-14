using FluentValidation;
using ModelLayer.Model;

namespace BusinessLayer.FluentValidator
{
    public class AddressBookValidatorRequest : AbstractValidator<AddressBookRequestDTO>
    {
        public AddressBookValidatorRequest()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
        }
    }
}
