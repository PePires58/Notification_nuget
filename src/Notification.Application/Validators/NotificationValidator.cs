using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Notification.Application.Validators
{
    [ExcludeFromCodeCoverage]
    public class NotificationValidator : AbstractValidator<Domain.Entities.Notification>
    {
        public NotificationValidator()
        {
            RuleFor(c => c)
                .Custom((c, context) =>
                {
                    EnsureInstanceNotNull(c);
                });

            RuleFor(c => c.Message)
                .NotNull().WithMessage("notification message cannot be empty or null")
                .NotEmpty().WithMessage("notification message cannot be empty or null");
        }
    }
}
