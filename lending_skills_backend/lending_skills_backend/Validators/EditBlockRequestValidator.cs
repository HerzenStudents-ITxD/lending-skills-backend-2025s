using FluentValidation;
using lending_skills_backend.Dtos;
using lending_skills_backend.Dtos.Requests;


namespace lending_skills_backend.Validators;

public class EditBlockRequestValidator : AbstractValidator<EditBlockRequest>
{
    public EditBlockRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Data).NotEmpty().WithMessage("Data is required.");
        RuleFor(x => x.IsExample).NotEmpty().WithMessage("IsExample is required.");
        RuleFor(x => x.Type).GreaterThanOrEqualTo(0).WithMessage("Type must be a non-negative integer.");
    }
}
