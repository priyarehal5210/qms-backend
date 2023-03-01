using FluentValidation;
using TaskManagementSystemBackend.Dto;
using TaskManagementSystemBackend.Models;

namespace TaskManagementSystemBackend.Validations
{
    public class RegisterValidations:AbstractValidator<RegisteredUsersDto>
    {
        public RegisterValidations()
        {
            RuleFor(p => p.Username).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("username can't be empty.").Length(2, 20);
            RuleFor(p => p.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("email can't be empty.").EmailAddress();
            RuleFor(p => p.Password).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("password can't be empty").Length(8, 12);
            RuleFor(p => p.ConfirmPassword).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("confirm password can't be empty").Equal(p=>p.Password).WithMessage("must match to password.").Length(8, 12);
        }
    }
}
