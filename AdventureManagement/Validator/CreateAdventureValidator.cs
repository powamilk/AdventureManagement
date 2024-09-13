using AdventureManagement.API.ViewModel.AdventureViewModel;
using FluentValidation;

namespace AdventureManagement.API.Validator
{
    public class CreateAdventureValidator : AbstractValidator<CreateAdventureVM>
    {
        public CreateAdventureValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title không được để trống")
                .Length(10, 100).WithMessage("Title phải từ 10 đến 100 ký tự");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description không được để trống")
                .MinimumLength(20).WithMessage("Description phải từ 20 ký tự trở lên");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location không được để trống");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Duration phải lớn hơn 0");

            RuleFor(x => x.OrganismIds)
                .NotEmpty().WithMessage("Phải có ít nhất một sinh vật liên quan");
        }
    }

}
