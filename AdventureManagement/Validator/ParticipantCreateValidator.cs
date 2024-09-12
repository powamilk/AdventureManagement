using AdventureManagement.API.ViewModel.Participant;
using FluentValidation;

namespace AdventureManagement.API.Validator
{
    public class ParticipantCreateValidator : AbstractValidator<ParticipantCreateVM>
    {
        public ParticipantCreateValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tên khoogn được bỏ trống")
                                .Length(10, 100).WithMessage("Tên người phải có độ dài từ 10 đến 100 ký tự");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email được bỏ trống")
                                .EmailAddress().WithMessage("Email không hợp lệ")
                                .Length(10, 100).WithMessage("Email phải có độ dài từ 10 đến 100 ký tự");
        }
    }
}
