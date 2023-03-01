using FluentValidation;
using TaskManagementSystemBackend.Models;

namespace TaskManagementSystemBackend.Validations
{
    public class TaskValidation:AbstractValidator<Tasks>
    {
        public TaskValidation() {
            RuleFor(p => p.Name).NotEmpty().WithMessage("task name can't be empty.");
        }
    }
}
