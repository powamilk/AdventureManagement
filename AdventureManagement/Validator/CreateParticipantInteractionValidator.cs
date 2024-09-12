using AdventureManagement.API.ViewModel.ParticipantInteraction;
using FluentValidation;

namespace AdventureManagement.API.Validator
{
    public class CreateParticipantInteractionValidator : AbstractValidator<CreateParticipantInteractionVM>
    {
        public CreateParticipantInteractionValidator()
        {
            RuleFor(x => x.AdventureId)
                .GreaterThan(0).WithMessage("AdventureId phải lớn hơn 0.");

            RuleFor(x => x.ParticipantId)
                .GreaterThan(0).WithMessage("ParticipantId phải lớn hơn 0.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating phải nằm trong khoảng từ 1 đến 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(500).WithMessage("Bình luận không được vượt quá 500 ký tự.");
        }
    }
}
