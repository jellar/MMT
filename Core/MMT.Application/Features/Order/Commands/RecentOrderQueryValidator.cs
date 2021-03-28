using FluentValidation;

namespace MMT.Application.Features.Order.Commands
{
    public class RecentOrderQueryValidator : AbstractValidator<RecentOrderQuery>
    {
        public RecentOrderQueryValidator()
        {
            RuleFor(o => o.CustomerId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(o => o.User)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
