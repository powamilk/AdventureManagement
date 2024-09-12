using AdventureManagement.API.ViewModel.ParticipantInteraction;
using FluentValidation;

namespace AdventureManagement.API.Validator
{
    public class UpdateParticipantInteractionValidator : AbstractValidator<UpdateParticipantInteractionVM>
    {
        public UpdateParticipantInteractionValidator()
        {
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating phải nằm trong khoảng từ 1 đến 5.");

            RuleFor(x => x.Comment)
                .MaximumLength(500).WithMessage("Bình luận không được vượt quá 500 ký tự.");
        }
    }
}
