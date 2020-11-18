/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using FluentValidation;

namespace Start_App.Application.HumanResources.Queries.V1.GetEmployeesWithPagination
{
    public class GetEmployeesWithPaginationQueryValidator : AbstractValidator<GetEmployeesWithPaginationQuery>
    {
        public GetEmployeesWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageIndex)
                .LessThan(0).WithMessage("PageSize at least greater than or equal to 0.");

            RuleFor(x => x.PageSize)
                .LessThanOrEqualTo(0).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
