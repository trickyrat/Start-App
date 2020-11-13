/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using FluentValidation;

namespace Start_App.Application.HumanResources.Commands.V1.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(e => e.JobTitle)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
