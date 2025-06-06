﻿using FluentValidation;
using lending_skills_backend.Dtos.Requests;

namespace lending_skills_backend.Validators;

public class AddTagToWorkRequestValidator : AbstractValidator<AddTagToWorkRequest>
{
    public AddTagToWorkRequestValidator()
    {
        RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required.");
        RuleFor(x => x.WorkId).NotEmpty().WithMessage("WorkId is required.");
    }
}